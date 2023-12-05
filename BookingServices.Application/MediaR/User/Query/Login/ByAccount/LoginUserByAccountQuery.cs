using MediatR;

namespace BookingServices.Application.MediaR.User.Query.Login.ByAccount;

public class LoginUserByAccountQuery : IRequest<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
