using GlobalMeet.Business.Dtos.Main.Post;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _professionService;
        public CategoryController(ICategoryService professionService)
        {
            _professionService = professionService;
        }


        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddCategory([FromForm] AddCategoryDto categoryDto)
        {
            var response = await _professionService.AddCategory(categoryDto);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateCategory([FromForm] AddCategoryDto categoryDto , int id)
        {
            var response = await _professionService.UpdateCategory(categoryDto, id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCategory(int id)
        {
            var response = await _professionService.GetCategory(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCategories()
        {
            var response = await _professionService.GetCategories();
            return Ok(response);
        }
    }
}
