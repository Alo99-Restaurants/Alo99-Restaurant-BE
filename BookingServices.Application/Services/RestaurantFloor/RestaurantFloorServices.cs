using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantFloorModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.RestaurantFloor
{
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
        public Task DeleteRestaurantFloorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiPaged<RestaurantFloorDTO>> GetAllRestaurantFloorsAsync(GetAllRestaurantFloorRequest request)
        {
            return new ApiPaged<RestaurantFloorDTO>
            {
                Items = _mapper.Map<IEnumerable<RestaurantFloorDTO>>(await _context.RestaurantFloors.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
                TotalRecords = await _context.RestaurantFloors.WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId).CountAsync()
            };
        }

        public async Task<RestaurantFloorDTO> GetRestaurantFloorByIdAsync(int id) => _mapper.Map<RestaurantFloorDTO>(await _context.RestaurantFloors.FindAsync(id));
        public async Task UpdateRestaurantFloorAsync(UpdateRestaurantFloorRequest restaurantFloor)
        {
            var mapper = _mapper.Map<Entities.Entities.RestaurantFloors>(restaurantFloor);

            _context.Update(mapper);
            await _context.SaveChangesAsync();
        }

    }
}
