using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetTypeController : ControllerBase
    {
        private readonly IMeetTypeService _meetTypeService;
        public MeetTypeController(IMeetTypeService meetTypeService)
        {
            _meetTypeService = meetTypeService;
        }

        [CustomAuthorize("SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddMeetType([FromForm] AddMeetTypeDto meetTypeDto)
        {
            var response = await _meetTypeService.AddMeetType(meetTypeDto);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> MeetType(int id)
        {
            var response = await _meetTypeService.GetMeetType(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner", "Moderator", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeetTypes()
        {
            var response = await _meetTypeService.GetMeetTypes();
            return Ok(response);
        }

    }
}
