using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using MediatR;

namespace BookingServices.Application.MediaR.Restaurant.Query.Gets
{
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, IEnumerable<Restaurants>>
    {
        private readonly BookingDbContext _context;
        public GetRestaurantsQueryHandler(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurants>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            return _context.Restaurants.ToList();
        }
    }
}
