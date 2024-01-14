using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.BookingModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.Services.Booking
{
    public class BookingServices : IBookingServices
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly IMapper _mapper;

        public BookingServices(BookingDbContext bookingDbContext, IMapper mapper)
        {
            _bookingDbContext = bookingDbContext;
            _mapper = mapper;
        }

        public async Task AddBookingAsync(AddBookingRequest booking)
        {
            var addBooking = _mapper.Map<Bookings>(booking);
            _bookingDbContext.Add(addBooking);
            await _bookingDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            //check exist booking
            var booking = _bookingDbContext.Bookings.Find(id);
            if (booking == null) throw new Exception("Booking not found");

            //delete booking
            _bookingDbContext.Remove(booking);
            await _bookingDbContext.SaveChangesAsync();
        }

        public async Task<ApiPaged<BookingDTO>> GetAllBookingAsync(GetAllBookingRequest request)
        {
            return new ApiPaged<BookingDTO>
            {
                Items = _mapper.Map<IEnumerable<BookingDTO>>(await _bookingDbContext.Bookings
                        .WhereIf(request.UserId != null, x=> x.CreatedBy ==request.UserId)
                        .WhereIf(request.CustomerId!= null,x=> x.CustomerId == request.CustomerId)
                        .WhereIf(request.TableId != null, x=> x.TableId == request.TableId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
                TotalRecords = await _bookingDbContext.Bookings.CountAsync()
            };
        }

        public async Task<BookingDTO> GetBookingByIdAsync(Guid id)
        {
            return _mapper.Map<BookingDTO>(await _bookingDbContext.Bookings.Include(x => x.Table).Include(x => x.Customer).FirstOrDefaultAsync(x=> x.Id == id));
        }

        public Task UpdateBookingAsync(UpdateBookingRequest booking)
        {
            //check exist
            var bookingEntity = _bookingDbContext.Bookings.Find(booking.Id);
            if (bookingEntity == null) throw new Exception("Booking not found");

            //map booking
            _mapper.Map(booking, bookingEntity);

            //update booking
            _bookingDbContext.Update(bookingEntity);
            //save changes
            _bookingDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
