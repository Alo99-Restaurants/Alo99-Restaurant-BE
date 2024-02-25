using AutoMapper;
using BookingServices.Entities.Contexts;

namespace BookingServices.Application.MediaR.Booking.Command.Update.Status;

public class BookingUpdateStatusCommandHandler : IRequestHandler<BookingUpdateStatusCommand, bool>
{
    private readonly BookingDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookingUpdateStatusCommandHandler(BookingDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public Task<bool> Handle(BookingUpdateStatusCommand request, CancellationToken cancellationToken)
    {
        //get all booking in list request
        var bookings = _dbContext.Bookings.Where(x => request.BookingIds.Contains(x.Id)).ToList();
        if (bookings.Count != request.BookingIds.Count) throw new ClientException("One of booking not exist");

        //update status
        foreach (var booking in bookings)
        {
            booking.BookingStatusId = request.BookingStatus;
            _dbContext.Update(booking);
        }

        //save change
        _dbContext.SaveChanges();
        return Task.FromResult(true);
    }
}
