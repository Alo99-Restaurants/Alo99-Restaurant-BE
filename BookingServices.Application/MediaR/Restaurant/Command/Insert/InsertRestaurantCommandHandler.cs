using AutoMapper;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using MediatR;

namespace BookingServices.Application.MediaR.Restaurant.Command.Insert
{
    public class InsertRestaurantCommandHandler : IRequestHandler<InsertRestaurantCommand, bool>
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public InsertRestaurantCommandHandler(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(InsertRestaurantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _mapper.Map<Restaurants>(request);
                _context.Add(data);
                var rs = await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

            }
            return true;
        }
    }
}
