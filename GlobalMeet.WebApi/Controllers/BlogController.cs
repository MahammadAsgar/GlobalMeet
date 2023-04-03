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
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IBlogFileService _blogFileService;
        public BlogController(IBlogService blogService, IUserService userService, IBlogFileService blogFileService)
        {
            _blogService = blogService;
            _userService = userService;
            _blogFileService = blogFileService;
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddBlog([FromForm] AddBlogDto blogDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _blogService.AddBlog(blogDto, (int)user.Data);
            if (response.Success)
            {
                blogDto.Files = Request.Form.Files;
                await _blogFileService.AddRangeAsync(blogDto, (int)response.Data);
            }
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetBlog(int id)
        {
            var response = await _blogService.GetBlog(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetBlogs()
        {
            var response = await _blogService.GetBlogs();
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetBlogsByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _blogService.GetBlogsByUser((int)user.Data);
            return Ok(response);
        }
    }
}
