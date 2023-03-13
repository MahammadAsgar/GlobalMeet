using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;
        public AboutController(IAboutService aboutService, IUserService userService)
        {
            _aboutService = aboutService;
            _userService = userService;
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddAbout([FromForm] AddAboutDto aboutDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _aboutService.AddAbout(aboutDto, (int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateAbout([FromForm] AddAboutDto aboutDto, int id)
        {
            var response = await _aboutService.UpdateAbout(aboutDto, id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAbout(int id)
        {
            var user = _userService.GetLoggedUser();
            var response = await _aboutService.GetAbout(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAbouts()
        {
            var user = _userService.GetLoggedUser();
            var response = await _aboutService.GetAbouts();
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Admin", "User")]
        //[CustomAuthorize("Admin", "Admin")]
        //[CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAboutByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _aboutService.GetAboutByUser((int)user.Data);
            return Ok(response);
        }
    }
}
