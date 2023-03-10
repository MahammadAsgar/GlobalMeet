using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<ICollection<Company>> GetCompanies()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> GetCompanyByUser(int userId)
        {
            return await GetAsQueryable()
                .Where(x => x.AppUsers.FirstOrDefault().Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
