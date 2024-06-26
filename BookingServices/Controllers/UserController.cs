﻿using BookingServices.Application.MediaR.User.Query.Login.ByAccount;
using BookingServices.Application.Services.User;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using BookingServices.Application.MediaR.User.Query.Login.ByGoogle;
using System.Net.Http.Headers;
using BookingServices.Application.MediaR.User.Command.NewFolder;
using BookingServices.Application.MediaR.User.Query.ResetPassword;
using BookingServices.Application.MediaR.User.Command.ResetPassword;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : MyControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserServices userServices, IMediator mediator, IHttpContextAccessor httpContextAccessor, ILogger<UserController> logger)
    {
        _userServices = userServices;
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    //get all user
    [HttpGet("")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiPaged<UserDTO>), 200)]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserRequest request) => ApiOk(await _userServices.GetAllUser(request));

    //get user by id
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResult<UserDTO>), 200)]
    public async Task<IActionResult> GetUser(Guid id)
    {
        //var userId = ClaimsPrincipalExtension.GetUserId(_httpContextAccessor.HttpContext?.User);
        return ApiOk(await _userServices.GetUserById(id));
    }

    //get user by profile
    [HttpGet("profile")]
    [ProducesResponseType(typeof(ApiResult<UserDTO>), 200)]
    public async Task<IActionResult> GetUserByProfile()
    {
        var userId = ClaimsPrincipalExtension.GetUserId(_httpContextAccessor.HttpContext?.User);
        return ApiOk(await _userServices.GetUserById(userId));
    }

    //get user by username
    [HttpGet("{username}")]
    [ProducesResponseType(typeof(ApiResult<UserDTO>), 200)]
    public async Task<IActionResult> GetUserByUsername(string username) => ApiOk(await _userServices.GetUserByUsername(username));

    //login
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult<LoginResponseModel>), 200)]
    public async Task<IActionResult> Login([FromBody] LoginUserByAccountQuery request)
    {
        var rs = await _mediator.Send(request);
        return ApiOk(rs);
    }

    //login with google
    [HttpGet("google-auth")]
    [AllowAnonymous]
    public IActionResult GoogleAuth()
    {
        //Console.WriteLine(JsonConvert.SerializeObject(HttpContext.Request.Headers));
        //// Check if the "Origin" header is present and allowed
        //if (HttpContext.Request.Headers.ContainsKey("Origin"))
        //{
        //    var values = HttpContext.Request.Headers["Origin"];
        //    Console.WriteLine(values);
        //    // Do stuff with the values... probably .FirstOrDefault()
        //}
        _logger.LogInformation(JsonConvert.SerializeObject(new AuthenticationProperties { RedirectUri =  Url.Action(nameof(GoogleCallback)) }));
        // Redirect to Google for authentication
        return Challenge(new AuthenticationProperties{ RedirectUri = Url.Action(nameof(GoogleCallback)) }, GoogleDefaults.AuthenticationScheme);
    }

    //dont show in swagger
    [HttpGet("google-callback")]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> GoogleCallback()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (result?.Succeeded == true)
        {
            // The user is authenticated successfully.
            // You can access user information from result.Principal

            // Example: Get user's email
            var userEmail = result.Principal?.FindFirst(ClaimTypes.Email)?.Value;
            //claim name
            var userName = result.Principal?.FindFirst(ClaimTypes.Name)?.Value;
            var rs =await _mediator.Send(new LoginUserByGoogleQuery
            {
                Email = userEmail,
                Name = userName
            });

            // Redirect to a secure endpoint or return a response
            return ApiOk(rs);
        }

        // Handle authentication failure, redirect to an error page, etc.
        throw new AuthenticationFailureException("");
    }

    //login with google by access token
    [HttpGet("google-auth-token")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult<LoginResponseModel>), 200)]
    public async Task<IActionResult> GoogleAuthByToken([FromQuery]string accessToken)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await client.GetAsync("https://www.googleapis.com/userinfo/v2/me");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var userInfor = JsonConvert.DeserializeObject<GoogleUserInfor>(responseBody);
                var request = new LoginUserByGoogleQuery
                {
                    Email = userInfor?.Email,
                    Name = userInfor?.Name,
                    Picture = userInfor?.Picture
                };
                var rs = await _mediator.Send(request);
                return ApiOk(rs);
            }
            else
            {
                if(response.StatusCode >= System.Net.HttpStatusCode.InternalServerError)
                {
                    throw new Exception("Failed to fetch user info. Status code: " + response.StatusCode);
                }
                else
                {
                    throw new ClientException(accessToken + " is invalid");
                }
            }
        }
    }

    //register
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> Register(RegisterUserCommand request)
    {
        var rs = await _mediator.Send(request);
        return ApiOk(rs);
    }

    //reset password request ResetPasswordQuery
    [HttpPost("reset-password-request")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> ResetPassword(ResetPasswordQuery request)
    {
        var rs = await _mediator.Send(request);
        return ApiOk(rs);
    }
    //reset password
    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand request)
    {
        var rs = await _mediator.Send(request);
        return ApiOk(rs);
    }
    [HttpGet("reset-password")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> ResetPasswordMethodGet([FromQuery]ResetPasswordCommand request)
    {
        var rs = await _mediator.Send(request);
        return ApiOk(rs);
    }

#if DEBUG
    //add user
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddUser(AddUserRequest user)
    {
        await _userServices.AddUser(user);
        return ApiOk();
    }

    //update user
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserData user)
    {
        await _userServices.UpdateUser(new UpdateUserRequest(user, id));
        return ApiOk();
    }
#endif
}
