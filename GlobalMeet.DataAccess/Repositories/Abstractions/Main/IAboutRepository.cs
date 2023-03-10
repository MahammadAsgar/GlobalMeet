using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<About> GetAbout(int id);
        Task<IEnumerable<About>> GetAbouts();
        //Task<About> GetAboutByUser(int userId);
    }
}
