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
    public class MeetDateController : ControllerBase
    {
        private readonly IMeetService _meetService;
        private readonly IUserService _userService;
        public MeetDateController(IMeetService meetService, IUserService userService)
        {
            _meetService = meetService;
            _userService = userService;
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddMeetDate([FromForm] AddMeetDateDto meetDateDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _meetService.AddMeet(meetDateDto, (int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateMeetDate([FromForm] AddMeetDateDto meetDateDto, int id)
        {
            var user = _userService.GetLoggedUser();
            var response = await _meetService.UpdateMeet(meetDateDto, id, (int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteMeetDate(int id)
        {
           //var user = _userService.GetLoggedUser();
            var response = await _meetService.DeleteMeet(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDate(int id)
        {
            var response = await _meetService.GetMeet(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDates()
        {
            var response = await _meetService.GetMeets();
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDatesByStatus(int statusId)
        {
            var response = await _meetService.GetMeetDatesByStatus(statusId);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDatesByCompany()
        {
            var user = _userService.GetLoggedUser();
            var response = await _meetService.GetMeetDatesByCompany((int)user.Data);
            return Ok(response);
        }
    }
}
