using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.UserModels;

namespace BookingServices.Application.Services.User;

public interface IUserServices
{
    //getalluser
    Task<ApiPaged<UserDTO>> GetAllUser(GetAllUserRequest request);
    //getuserbyid
    Task<UserDTO> GetUserById(Guid id);
    //adduser
    Task AddUser(AddUserRequest user);
    //updateuser
    Task UpdateUser(UpdateUserRequest user);
    //deleteuser
    Task DeleteUser(int id);
    //byusername
    Task<UserDTO> GetUserByUsername(string username);
}
