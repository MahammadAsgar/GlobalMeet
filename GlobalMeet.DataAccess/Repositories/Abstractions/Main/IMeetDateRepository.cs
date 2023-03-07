using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeetDateRepository : IGenericRepository<MeetDate>
    {
        Task<MeetDate> GetMeetDate(int id);
        Task<IEnumerable<MeetDate>> GetMeetDatesByStatus(int status);
        Task<IEnumerable<MeetDate>> GetMeetDatesByUser(int userId);
        Task<MeetDate> GetMeetDateByUser(int userId, int id);
        Task<IEnumerable<MeetDate>> GetMeetDatesByUserStatus(int userId, int statusId);
        Task<IEnumerable<MeetDate>> GetMeetDatesFree(int userId, bool isFree);
        Task<IEnumerable<MeetDate>> GetMeetDates();
        Task<MeetDate> GetLastMeet();
    }
}
