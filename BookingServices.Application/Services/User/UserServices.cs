using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantModels;
using BookingServices.Model.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;
        public UserServices(IMapper mapper, BookingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddUser(AddUserRequest user)
        {
            user.Password = Core.Utils.HashPassword(user.Password);
            _context.Add(_mapper.Map<Users>(user));
            await _context.SaveChangesAsync();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiPaged<UserDTO>> GetAllUser(GetAllUserRequest request)
        {
            return new ApiPaged<UserDTO>
            {
                Items = _mapper.Map<IEnumerable<UserDTO>>(await _context.Users.Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
                TotalRecords = await _context.Users.CountAsync()
            };
        }

        public async Task<UserDTO> GetUserById(Guid id) => _mapper.Map<UserDTO>(await _context.Users.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<UserDTO> GetUserByUsername(string username)
        {
            return _mapper.Map<UserDTO>(source: await _context.Users.FirstOrDefaultAsync(x => x.Username == username));
        }

        public async Task UpdateUser(UpdateUserRequest user)
        {
            var mapper = _mapper.Map<Users>(user);
            
            _context.Update(mapper);
            await _context.SaveChangesAsync();
        }
    }
}
