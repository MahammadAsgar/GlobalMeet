using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionService _professionService;
        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }


        //[CustomAuthorize("SuperAdmin", "SuperAdmin")]
        //[HttpPost]
        //[ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        ////public async Task<ActionResult<ServiceResult>> AddProfession([FromForm] AddProfessionDto professionDto)
        ////{
        ////    var response = await _professionService.AddProfession(professionDto);
        ////    return Ok(response);
        ////}

        //[CustomAuthorize("SuperAdmin", "SuperAdmin")]
        //[HttpPut]
        //[ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<ServiceResult>> UpdateProfession([FromForm] AddProfessionDto professionDto, int id)
        //{
        //    var response = await _professionService.UpdateProfession(professionDto, id);
        //    return Ok(response);
        //}


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetProfession(int id)
        {
            var response = await _professionService.GetProfession(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetProfessions()
        {
            var response = await _professionService.GetProfessions();
            return Ok(response);
        }
    }
}
