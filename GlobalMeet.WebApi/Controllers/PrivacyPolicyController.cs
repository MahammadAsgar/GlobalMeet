using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Implementations.Main;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrivacyPolicyController : ControllerBase
    {
        private readonly IPrivacyPolicyService _privacyPolicyService;
        public PrivacyPolicyController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddPrivacyPolicy([FromForm] AddPrivacyPolicyDto privacyPolicyDto)
        {
            var response = await _privacyPolicyService.AddPrivacyPolicy(privacyPolicyDto);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdatePrivacyPolicy([FromForm] AddPrivacyPolicyDto privacyPolicyDto, int typeId)
        {
            var response = await _privacyPolicyService.UpdatePrivacyPolicy(privacyPolicyDto, typeId);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetPrivacyPolicy(int typeId)
        {
            var response = await _privacyPolicyService.GetPrivacyPolicy(typeId);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetPrivacyPolicies()
        {
            var response = await _privacyPolicyService.GetPrivacyPolicies();
            return Ok(response);
        }
    }
}
