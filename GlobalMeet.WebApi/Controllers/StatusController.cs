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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddStatus([FromForm] AddStatusDto statusDto)
        {
            var response = await _statusService.AddStatus(statusDto);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateStatus([FromForm] AddStatusDto statusDto, int id)
        {
            var response = await _statusService.UpdateStatus(statusDto, id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteStatus(int id)
        {
            var response = await _statusService.DeleteStatus(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetStatus(int id)
        {
            var response = await _statusService.GetStatus(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetStatuses()
        {
            var response = await _statusService.GetStatuses();
            return Ok(response);
        }
    }
}
