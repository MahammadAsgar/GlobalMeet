using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeetTypeRepository : IGenericRepository<MeetType>
    {
        Task<MeetType> GetMeetType(int id);
        Task<ICollection<MeetType>> GetMeetTypes();
    }
}
