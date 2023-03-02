using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IBlogService
    {
        Task<ServiceResult> AddBlog(AddBlogDto blogDto);
        Task<ServiceResult> UpdateBlog(AddBlogDto blogDto, int id);
        Task<ServiceResult> DeleteBlog(AddBlogDto blogDto, int id);
        Task<ServiceResult> GetBlog(int id);
        Task<ServiceResult> GetBlogs();
        Task<ServiceResult> GetBlogsByUser(int userId);
    }
}
