using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IProfessionRepository : IGenericRepository<Profession>
    {
        Task<Profession> GetProfession(int id);
        Task<IEnumerable<Profession>> GetProfessions();
    }
}
