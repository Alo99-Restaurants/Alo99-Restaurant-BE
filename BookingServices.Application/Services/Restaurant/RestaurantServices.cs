using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.Restaurant;

public class RestaurantServices : IRestaurantServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public RestaurantServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task AddRestaurantAsync(AddRestaurantRequest restaurant)
    {
        _context.Add(_mapper.Map<Restaurants>(restaurant));
        await _context.SaveChangesAsync();
    }

    public Task DeleteRestaurantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiPaged<RestaurantDTO>> GetAllRestaurantsAsync(GetAllRestaurantRequest request)
    {
        return new ApiPaged<RestaurantDTO>
        {
            Items = _mapper.Map<IEnumerable<RestaurantDTO>>(await _context.Restaurants.Include(x => x.RestaurantImages).Include(x => x.RestaurantFloors).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.Restaurants.CountAsync()
        };
    }

    public async Task<RestaurantDTO> GetRestaurantByIdAsync(int id) => _mapper.Map<RestaurantDTO>(await _context.Restaurants.Include(x => x.RestaurantImages).Include(x => x.RestaurantFloors).FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateRestaurantAsync(UpdateRestaurantRequest restaurant)
    {
        //get res by id
        var restaunrant = await _context.Restaurants.FindAsync(restaurant.Id);
        //if null throw exception
        if (restaunrant == null) throw new Exception("Restaurant not found");

        _mapper.Map(restaurant, restaunrant);

        _context.Update(restaunrant);
        await _context.SaveChangesAsync();
    }
}
