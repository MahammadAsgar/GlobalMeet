using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeetDateRepository : IGenericRepository<MeetDate>
    {
        Task<MeetDate> GetMeetDate(int id);
        Task<ICollection<MeetDate>> GetMeetDatesByCompany(int companyId);
        Task<ICollection<MeetDate>> GetMeetDatesByStatus(int statusId);
        Task<ICollection<MeetDate>> GetMeetDates();

        Task<ICollection<MeetDate>> GetDatesInToday();
        Task<decimal> GetTotaIncome(int companyId);
    }
}
