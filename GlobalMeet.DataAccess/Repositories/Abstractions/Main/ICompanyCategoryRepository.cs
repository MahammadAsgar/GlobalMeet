using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface ICompanyCategoryRepository : IGenericRepository<CompanyCategory>
    {
        Task<CompanyCategory> GetCompanyCategory(int id);
        Task<ICollection<CompanyCategory>> GetCompanyCategories();
    }
}
