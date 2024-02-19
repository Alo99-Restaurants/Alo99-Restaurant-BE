using BookingServices.Model.UserModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Application.MediaR.User.Query.Login.ByGoogle;

public class LoginUserByGoogleQuery : IRequest<LoginResponseModel>
{
    [Required(ErrorMessage = "Email is null")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Name is null")]
    public string Name { get; set; }
    public string Picture { get; set; }
    
}
