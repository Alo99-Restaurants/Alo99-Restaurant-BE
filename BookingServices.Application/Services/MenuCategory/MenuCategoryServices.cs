using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.MenuCategoryModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.MenuCategory;

public class MenuCategoryServices : IMenuCategoryServices
{
    private readonly IMapper _mapper;
    private readonly BookingDbContext _bookingDbContext;
    public MenuCategoryServices(IMapper mapper, BookingDbContext bookingDbContext)
    {
        _mapper = mapper;
        _bookingDbContext = bookingDbContext;
    }

    public async Task AddMenuCategory(AddMenuCategoryRequest request)
    {
        _bookingDbContext.Add(_mapper.Map<MenuCategories>(request));
        await _bookingDbContext.SaveChangesAsync();
    }

    public async Task DeleteMenuCategory(Guid id)
    {
        //check if menu category is exist
        var menuCategory = _bookingDbContext.MenuCategories.FirstOrDefault(x => x.Id == id);
        //if not exist throw exception
        if (menuCategory == null)
        {
            throw new Exception("Menu Category not found");
        }
        //if exist delete
        _bookingDbContext.Remove(menuCategory);
        await _bookingDbContext.SaveChangesAsync();

    }

    public async Task<ApiPaged<MenuCategoryDTO>> GetAllMenuCategories(GetAllMenuCategoryRequest request)
    {
        return new ApiPaged<MenuCategoryDTO>
        {
            Items = _mapper.Map<IEnumerable<MenuCategoryDTO>>(await _bookingDbContext.MenuCategories.Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _bookingDbContext.MenuCategories.CountAsync()
        };
    }

    public async Task<MenuCategoryDTO> GetMenuCategoryById(Guid id) => _mapper.Map<MenuCategoryDTO>(await _bookingDbContext.MenuCategories.Include(x => x.RestaurantMenus).FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateMenuCategory(UpdateMenuCategoryRequest request)
    {
        //check exist
        var menuCategory = _bookingDbContext.MenuCategories.FirstOrDefault(x => x.Id == request.Id);
        //check null throw exception
        if (menuCategory == null) throw new Exception("Menu category not found");
        //update
        _mapper.Map(request, menuCategory);
        _bookingDbContext.Update(menuCategory);
        await _bookingDbContext.SaveChangesAsync();
    }

}
