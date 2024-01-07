using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.Services.RestaurantImage;

public class RestaurantImageServices : IRestaurantImageServices
{
    private readonly IMapper _mapper;
    private readonly BookingDbContext _context;

    public RestaurantImageServices(IMapper mapper, BookingDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task AddRestaurantImageAsync(AddRestaurantImageRequest request)
    {
        _context.Add(_mapper.Map<RestaurantImages>(request));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantImageAsync(Guid id)
    {
        //check exist
        var restaurantImage = _context.RestaurantImages.FirstOrDefault(x => x.Id == id);
        //check null thrwo exception
        if (restaurantImage == null) throw new Exception("Restaurant image not found");
        //remove
        _context.Remove(restaurantImage);
        await _context.SaveChangesAsync();

    }

    public async Task<ApiPaged<RestaurantImageDTO>> GetAllRestaurantImageAsync(GetallRestaurantImageRequest request)
    {
        //check retaurant exist
        if (request.RestaurantId != null)
        {
            var restaurant = await _context.Restaurants.FindAsync(request.RestaurantId);
            if (restaurant == null) throw new Exception("Restaurant not found");
        }

        return new ApiPaged<RestaurantImageDTO>
        {
            Items = _mapper.Map<IEnumerable<RestaurantImageDTO>>(await _context.RestaurantImages.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords =await _context.RestaurantImages.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).CountAsync()
        };
    }

    public async Task<RestaurantImageDTO> GetRestaurantImageByIdAsync(Guid id) => _mapper.Map<RestaurantImageDTO>(await _context.RestaurantImages.FindAsync(id));

    public Task UpdateRestaurantImageAsync(UpdateRestaurantImageRequest request)
    {
        //check exist
        var restaurantImage = _context.RestaurantImages.FirstOrDefault(x => x.Id == request.Id);
        //check null thrwo exception
        if (restaurantImage == null) throw new Exception("Restaurant image not found");

        //update
        _mapper.Map(request, restaurantImage);
        _context.Update(restaurantImage);

        return _context.SaveChangesAsync();
    }
}
