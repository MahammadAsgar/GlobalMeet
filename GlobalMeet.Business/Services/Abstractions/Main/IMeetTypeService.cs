using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IMeetTypeService
    {
        Task<ServiceResult> AddMeetType(AddMeetTypeDto meetTypeDto);
        Task<ServiceResult> GetMeetType(int id);
        Task<ServiceResult> GetMeetTypes();
    }
}
