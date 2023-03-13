using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Implementations.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyCategoryController : ControllerBase
    {
        private readonly ICompanyCategoryService _companyCategoryService;
        public CompanyCategoryController(ICompanyCategoryService companyCategoryService)
        {
            _companyCategoryService = companyCategoryService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddCompanyCategory([FromForm] AddCompanyCategoryDto companyCategoryDto)
        {
            var response = await _companyCategoryService.AddCompanyCategory(companyCategoryDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateCompanyCategory([FromForm] AddCompanyCategoryDto companyCategoryDto, int id)
        {
            var response = await _companyCategoryService.UpdateCompanyCategory(companyCategoryDto, id);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompanyCategory(int id)
        {
            var response = await _companyCategoryService.GetCompanyCategory(id);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompanyCategories()
        {
            var response = await _companyCategoryService.GetCompanyCategories();
            return Ok(response);
        }
    }
}
