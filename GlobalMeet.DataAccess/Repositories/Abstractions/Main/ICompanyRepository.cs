using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company> GetCompany(int id);
        Task<Company> GetCompanyByUser(int userId);
        Task<ICollection<Company>> GetCompanies();
    }
}
