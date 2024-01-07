using BookingServices.Model.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Query.Login.ByGoogle;

public class LoginUserByGoogleQuery : IRequest<LoginResponseModel>
{
    [Required(ErrorMessage = "Email is null")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Name is null")]
    public string Name { get; set; }
}
