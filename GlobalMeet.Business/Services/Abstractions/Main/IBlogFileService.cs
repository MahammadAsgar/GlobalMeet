using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IBlogFileService
    {
        Task<ServiceResult> AddRangeAsync(AddBlogDto blog, int blogId);
        Task<ServiceResult> UpdateRangeAsync(AddBlogDto blog, int blogId);
    }
}
