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
        public async Task<ActionResult<ServiceResult>> DeleteMeetDate(int id, int userId)
        {
            var user = _userService.GetLoggedUser();
            var response = await _meetService.DeleteMeet(id, (int)user.Data);
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
        public async Task<ActionResult<ServiceResult>> GetMeetDatesByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _meetService.GetMeetDatesByUser((int)user.Data);
            return Ok(response);
        }




        /*ask<ServiceResult> AddMeet(AddMeetDateDto meetDateDto, int userId);
        Task<ServiceResult> UpdateMeet(AddMeetDateDto meetDateDto, int id, int userId);
        Task<ServiceResult> DeleteMeet(int id, int userId);
        Task<ServiceResult> GetMeet(int id);
        Task<ServiceResult> GetMeets();
        Task<ServiceResult> GetMeetDatesByStatus(int status);
        Task<ServiceResult> GetMeetDatesByUser(int userId);
        Task<ServiceResult> GetMeetDatesByUserStatus(int userId, int statusId);
        Task<ServiceResult> GetMeetDatesFree(int userId, bool isFree);*/

    }
}
