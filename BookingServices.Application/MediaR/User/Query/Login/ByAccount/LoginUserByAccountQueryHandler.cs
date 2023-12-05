using BookingServices.Entities.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static BookingServices.Core.Models.AppConfigurations;

namespace BookingServices.Application.MediaR.User.Query.Login.ByAccount;

public class LoginUserByAccountQueryHandler : IRequestHandler<LoginUserByAccountQuery, string>
{
    public readonly BookingDbContext _bookingDbContext;
    private readonly JwtConfigurations _jwt;

    public LoginUserByAccountQueryHandler(BookingDbContext bookingDbContext, IOptions<JwtConfigurations> jwt)
    {
        _bookingDbContext = bookingDbContext;
        _jwt = jwt.Value ?? throw new ArgumentNullException("jwt not config");
    }

    public async Task<string> Handle(LoginUserByAccountQuery request, CancellationToken cancellationToken)
    {
        var user = await _bookingDbContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (!Core.Utils.VerifyPassword(request.Password, user.Password)) throw new ClientException("Password is incorrect");


        return Core.Identity.JwtTokenGenerator.GenerateJwtToken(_jwt.SecretKey, user.Id.ToString(), _jwt.Issuer, _jwt.Audience, new List<string> { user.Role.ToString() }, _jwt.ExpirationMinutes);
    }
}
