using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IAboutService
    {
        Task<ServiceResult> AddAbout(AddAboutDto aboutDto, int uerId);
        Task<ServiceResult> UpdateAbout(AddAboutDto aboutDto, int id, int userId);
        Task<ServiceResult> GetAbout(int id);
        Task<ServiceResult> GetAbouts();
        Task<ServiceResult> GetAboutByUser(int userId);
    }
}
