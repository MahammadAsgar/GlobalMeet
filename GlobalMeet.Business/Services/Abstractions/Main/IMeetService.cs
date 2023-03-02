using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IMeetService
    {
        Task<ServiceResult> AddMeet(AddMeetDateDto meetDateDto);
        Task<ServiceResult> UpdateMeet(AddMeetDateDto meetDateDto, int id);
        Task<ServiceResult> DeleteMeet(int id);
        Task<ServiceResult> GetMeet(int id);
        Task<ServiceResult> GetMeets();
        Task<ServiceResult> GetMeetDatesByStatus(int status);
        Task<ServiceResult> GetMeetDatesByUser(int userId);
        Task<ServiceResult> GetMeetDatesByUserStatus(int userId, int statusId);
        Task<ServiceResult> GetMeetDatesFree(int userId, bool isFree);
    }
}
