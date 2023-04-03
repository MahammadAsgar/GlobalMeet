using GlobalMeet.Business.Dtos.User.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetUser(int userId)
        {
            return Ok(await _userService.GetUser(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> Register([FromForm] RegisterUserDto registerUserDto)
        {
            await _userService.Register(registerUserDto);
            var user = await _userService.GetLastUser();
            return Ok(await _userService.AddClaim(new AddClaimDto() { UserId = user.Data.ToString(), ClaimName = "User", ClaimType = "User" }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> LogIn([FromForm] LoginUserDto loginUserDto)
        {
            return Ok(await _userService.LogIn(loginUserDto));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> LogOut()
        {
            return Ok(await _userService.LogOut());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public IActionResult GetLoggedUser()
        {
            return Ok(_userService.GetLoggedUser());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddClaim([FromForm] AddClaimDto addClaimDto)
        {
            return Ok(await _userService.AddClaim(addClaimDto));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> RemoveClaim(string userId)
        {
            return Ok(await _userService.RemoveClaim(userId));
        }



        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> PasswordResetAsync(string email)
        {
            return Ok(await _userService.PasswordResetAsync(email));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdatePassword(string userName, string token, string password, string confirmPassword)
        {
            return Ok(await _userService.UpdatePassword(userName, token, password));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> EmailConfirmAsync(string email)
        {
            return Ok(await _userService.EmailConfirmAsync(email));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> VerifyConfirmAsync(string userName, string confirmToken)
        {
            return Ok(await _userService.VerifyConfirmAsync(userName, confirmToken));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> VerifyResetTokenAsync(string resetToke, string userName)
        {
            return Ok(await _userService.VerifyResetTokenAsync(resetToke, userName));
        }



        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeActiveUser(string userId)
        {
            return Ok(await _userService.DeActiveUser(userId));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> ActivateUser(string userId)
        {
            return Ok(await _userService.ActivateUser(userId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetActiveUsers()
        {
            return Ok(await _userService.GetActiveUsers());
        }
    }
}
