using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetDateController : ControllerBase
    {
        private readonly IMeetService _meetService;
        public MeetDateController(IMeetService meetService)
        {
            _meetService = meetService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddMeetDate([FromForm] AddMeetDateDto meetDateDto, int userId)
        {
            var response = await _meetService.AddMeet(meetDateDto, userId);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateMeetDate([FromForm] AddMeetDateDto meetDateDto, int id, int userId)
        {
            var response = await _meetService.UpdateMeet(meetDateDto, id, userId);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteMeetDate(int id, int userId)
        {
            var response = await _meetService.DeleteMeet(id, userId);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDate(int id)
        {
            var response = await _meetService.GetMeet(id);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetDates()
        {
            var response = await _meetService.GetMeets();
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
