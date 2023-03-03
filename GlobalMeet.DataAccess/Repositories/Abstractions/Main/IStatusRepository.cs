using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IStatusRepository : IGenericRepository<Status>
    {
        Task<Status> GetStatus(int id);
        Task<IEnumerable<Status>> GetStatuses();
    }
}
