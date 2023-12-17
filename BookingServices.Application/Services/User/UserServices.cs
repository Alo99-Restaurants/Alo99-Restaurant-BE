using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.UserModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.User;

public class UserServices : IUserServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;
    public UserServices(IMapper mapper, BookingDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<UserDTO> AddUser(AddUserRequest user)
    {
        user.Password = Core.Utils.HashPassword(user.Password);
        var adduser = _mapper.Map<Users>(user);
        _context.Add(adduser);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(adduser);
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
        //get user by id and check if null
        var userEntity = await _context.Users.FindAsync(user.Id);
        if (userEntity == null) throw new Exception("User not found");

        _mapper.Map(user, userEntity);

        _context.Update(userEntity);
        await _context.SaveChangesAsync();
    }
}
