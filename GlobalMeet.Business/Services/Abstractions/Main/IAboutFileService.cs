using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IAboutFileService
    {
        Task<ServiceResult> AddRangeAsync(AddAboutDto about, int aboutId);
        Task<ServiceResult> UpdateRangeAsync(AddAboutDto about, int aboutId);
    }
}
