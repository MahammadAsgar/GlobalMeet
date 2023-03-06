using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IArchivedMeetRepository : IGenericRepository<ArchivedMeet>
    {
        Task<ArchivedMeet> GetArchivedMeet(int id);
        Task<ICollection<ArchivedMeet>> GetArchivedMeetByUser(int userId);
    }
}
