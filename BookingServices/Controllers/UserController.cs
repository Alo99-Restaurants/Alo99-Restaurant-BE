using BookingServices.Application.MediaR.User.Query.Login.ByAccount;
using BookingServices.Application.Services.User;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Enum;
using BookingServices.Model.RestaurantModels;
using BookingServices.Model.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MyControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public UserController(IUserServices userServices, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _userServices = userServices;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        //get all user
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiPaged<UserDTO>), 200)]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserRequest request) => ApiOk(await _userServices.GetAllUser(request));

        //get user by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<UserDTO>), 200)]
        public async Task<IActionResult> GetUser(Guid id) => ApiOk(await _userServices.GetUserById(id));

        //get user by username
        [HttpGet("username/{username}")]
        [ProducesResponseType(typeof(ApiResult<UserDTO>), 200)]
        public async Task<IActionResult> GetUserByUsername(string username) => ApiOk(await _userServices.GetUserByUsername(username));

        //login
        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResult<string>), 200)]
        public async Task<IActionResult> Login([FromBody]LoginUserByAccountQuery request)
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
}
