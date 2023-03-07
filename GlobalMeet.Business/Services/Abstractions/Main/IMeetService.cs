using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IMeetService
    {
        Task<ServiceResult> AddMeet(AddMeetDateDto meetDateDto, int userId);
        Task<ServiceResult> UpdateMeet(AddMeetDateDto meetDateDto, int id, int userId);
        Task<ServiceResult> DeleteMeet(int id, int userId);
        Task<ServiceResult> GetMeet(int id);
        Task<ServiceResult> GetMeets();
        Task<ServiceResult> GetMeetDatesByStatus(int status);
        Task<ServiceResult> GetMeetDatesByUser(int userId);
        Task<ServiceResult> GetMeetDatesByUserStatus(int userId, int statusId);
        Task<ServiceResult> GetMeetDatesFree(int userId, bool isFree);

        Task<ServiceResult> ChangeJoined(int userId, int id, bool joined);
    }
}
