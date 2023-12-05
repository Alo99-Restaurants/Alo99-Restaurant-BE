using BookingServices.Entities.Entities;
using MediatR;

namespace BookingServices.Application.MediaR.Restaurant.Query.Gets;

public class GetRestaurantsQuery : IRequest<IEnumerable<Restaurants>>
{
}
