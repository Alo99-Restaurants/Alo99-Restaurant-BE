using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantModels;
using BookingServices.Model.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.Services.User
{
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
}
