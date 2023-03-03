using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IStatusService
    {
        Task<ServiceResult> AddStatus(AddStatusDto statusDto);
        Task<ServiceResult> UpdateStatus(AddStatusDto statusDto, int id);
        Task<ServiceResult> DeleteStatus(int id);
        Task<ServiceResult> GetStatus(int id);
        Task<ServiceResult> GetStatuses();
    }
}
