using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantMenuModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.Menu;

public class RestaurantMenuServices : IRestaurantMenuServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public RestaurantMenuServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddRestaurantMenuAsync(AddRestaurantMenuRequest request)
    {
        _context.Add(_mapper.Map<RestaurantMenu>(request));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantMenuAsync(Guid id)
    {
        //check if restaurant menu is exist
        var restaurantMenu = _context.RestaurantMenu.FirstOrDefault(x => x.Id == id);
        //if not exist throw exception
        if (restaurantMenu == null)
        {
            throw new Exception("Restaurant Menu not found");
        }
        //if exist delete
        _context.Remove(restaurantMenu);
        await _context.SaveChangesAsync();
    }

    public async Task<ApiPaged<RestaurantMenuDTO>> GetAllRestaurantMenuAsync(GetAllRestaurantMenuRequest request)
    {
        return new ApiPaged<RestaurantMenuDTO>
        {
            Items = _mapper.Map<IEnumerable<RestaurantMenuDTO>>(await _context.RestaurantMenu.WhereIf(request.MenuCategoryId != null, x => x.MenuCategoryId == request.MenuCategoryId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.RestaurantMenu.WhereIf(request.MenuCategoryId != null, x => x.MenuCategoryId == request.MenuCategoryId).CountAsync()
        };
    }

    public async Task<RestaurantMenuDTO> GetRestaurantMenuByIdAsync(Guid id) => _mapper.Map<RestaurantMenuDTO>(await _context.RestaurantMenu.FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateRestaurantMenuAsync(UpdateRestaurantMenuRequest request)
    {
        //check exist
        var restaurantMenu =await _context.RestaurantMenu.FirstOrDefaultAsync(x => x.Id == request.Id);
        //check null throw exception
        if (restaurantMenu == null) throw new Exception("Restaurant menu not found");
        //update
        _mapper.Map(request, restaurantMenu);
        _context.Update(restaurantMenu);
        await _context.SaveChangesAsync();

    }
}
