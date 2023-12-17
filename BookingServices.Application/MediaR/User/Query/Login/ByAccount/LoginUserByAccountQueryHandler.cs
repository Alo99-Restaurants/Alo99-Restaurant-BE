using AutoMapper;
using BookingServices.Entities.Contexts;
using BookingServices.Model.UserModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static AppConfigurations;

namespace BookingServices.Application.MediaR.User.Query.Login.ByAccount;

public class LoginUserByAccountQueryHandler : IRequestHandler<LoginUserByAccountQuery, LoginResponseModel>
{
    private readonly IMapper _mapper;
    public readonly BookingDbContext _bookingDbContext;
    private readonly JwtConfigurations _jwt;

    public LoginUserByAccountQueryHandler(BookingDbContext bookingDbContext, IOptions<JwtConfigurations> jwt, IMapper mapper)
    {
        _bookingDbContext = bookingDbContext;
        _jwt = jwt.Value ?? throw new ArgumentNullException("jwt not config");
        _mapper = mapper;
    }

    public async Task<LoginResponseModel> Handle(LoginUserByAccountQuery request, CancellationToken cancellationToken)
    {
        var user = await _bookingDbContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (!Core.Utils.VerifyPassword(request.Password, user.Password)) throw new ClientException("Password is incorrect");

        var token = Core.Identity.JwtTokenGenerator.GenerateJwtToken(_jwt.SecretKey, user.Id.ToString(), _jwt.Issuer, _jwt.Audience, new List<string> { user.Role.ToString() }, _jwt.ExpirationMinutes);
        return new LoginResponseModel
        {
            JwtToken = token,
            UserInfor = _mapper.Map<UserDTO>(user)
        };
    }
}
