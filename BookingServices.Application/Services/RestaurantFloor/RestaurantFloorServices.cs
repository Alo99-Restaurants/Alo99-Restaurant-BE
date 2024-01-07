using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantFloorModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.RestaurantFloor;

public class RestaurantFloorServices : IRestaurantFloorServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public RestaurantFloorServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddRestaurantFloorAsync(AddRestaurantFloorRequest restaurantFloor)
    {
        _context.Add(_mapper.Map<RestaurantFloors>(restaurantFloor));
        await _context.SaveChangesAsync();
    }
    public async Task DeleteRestaurantFloorAsync(Guid id)
    {
        //check exist
        var restaurantFloor =await _context.RestaurantFloors.FirstOrDefaultAsync(x => x.Id == id);
        //check null thrwo exception
        if (restaurantFloor == null) throw new Exception("Restaurant floor not found");
        //remove
        _context.Remove(restaurantFloor);
        await _context.SaveChangesAsync();
    }

    public async Task<ApiPaged<RestaurantFloorDTO>> GetAllRestaurantFloorsAsync(GetAllRestaurantFloorRequest request)
    {
        //check retaurant exist
        if (request.RestaurantId != null)
        {
            var restaurant = await _context.Restaurants.FindAsync(request.RestaurantId);
            if (restaurant == null) throw new Exception("Restaurant not found");
        }

        return new ApiPaged<RestaurantFloorDTO>
        {
            Items = _mapper.Map<IEnumerable<RestaurantFloorDTO>>(await _context.RestaurantFloors.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.RestaurantFloors.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).CountAsync()
        };
    }

    public async Task<RestaurantFloorDTO> GetRestaurantFloorByIdAsync(Guid id) => _mapper.Map<RestaurantFloorDTO>(await _context.RestaurantFloors.FindAsync(id));
    public async Task UpdateRestaurantFloorAsync(UpdateRestaurantFloorRequest restaurantFloor)
    {
        //get byid and check if null
        var restaurantFloorEntity = await _context.RestaurantFloors.FindAsync(restaurantFloor.Id);
        if (restaurantFloorEntity == null) throw new Exception("Restaurant floor not found");

        _mapper.Map(restaurantFloor, restaurantFloorEntity);

        _context.Update(restaurantFloorEntity);
        await _context.SaveChangesAsync();
    }

}
