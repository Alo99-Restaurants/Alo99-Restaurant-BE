using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.MenuImageModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.MenuImage;

public class MenuImageServices : IMenuImageServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public MenuImageServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddMenuImageAsync(AddMenuImageRequest request)
    {
        //mapper
        _context.Add(_mapper.Map<MenuImages>(request));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuImageAsync(Guid id)
    {
        //check exist if null throw exception
        var checkExist = _context.MenuImages.FirstOrDefault(x => x.Id == id);
        if (checkExist == null) throw new Exception("Menu image not found");

        //remove
        _context.Remove(checkExist);
        await _context.SaveChangesAsync();
    }

    public async Task<ApiPaged<MenuImageDTO>> GetAllMenuImageAsync(GetAllMenuImageRequest request)
    {
        return new ApiPaged<MenuImageDTO>
        {
            Items = _mapper.Map<IEnumerable<MenuImageDTO>>(await _context.MenuImages.WhereIf(request.RestaurantMenuId != null, x=> x.MenuId == request.RestaurantMenuId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = _context.MenuImages.Count()
        };
    }

    public async Task<MenuImageDTO> GetMenuImageByIdAsync(Guid id) =>  _mapper.Map<MenuImageDTO>(await _context.MenuImages.FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateMenuImageAsync(UpdateMenuImageRequest request)
    {
        //check exist if null throw exception
        var checkExist = _context.MenuImages.FirstOrDefault(x => x.Id == request.Id);
        if (checkExist == null) throw new Exception("Menu image not found");

        //mapper
        _mapper.Map(request, checkExist);
        _context.Update(checkExist);
        await _context.SaveChangesAsync();
    }
}
