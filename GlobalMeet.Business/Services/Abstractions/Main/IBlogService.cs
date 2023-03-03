using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IBlogService
    {
        Task<ServiceResult> AddBlog(AddBlogDto blogDto, int userId);
        Task<ServiceResult> UpdateBlog(AddBlogDto blogDto, int id);
        Task<ServiceResult> DeleteBlog(AddBlogDto blogDto, int id, int userId);
        Task<ServiceResult> GetBlog(int id);
        Task<ServiceResult> GetBlogs();
        Task<ServiceResult> GetBlogsByUser(int userId);
    }
}
