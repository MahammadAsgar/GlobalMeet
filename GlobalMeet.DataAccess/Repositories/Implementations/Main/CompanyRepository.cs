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
                .Include(x => x.CompanyCategory)
                .Include(x => x.About)
                .Include(x => x.Blogs)
                .Include(x => x.MeetDates)
                .ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.CompanyCategory)
                .Include(x => x.About)
                .Include(x => x.Blogs)
                .Include(x => x.MeetDates)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> GetCompanyByUser(int userId)
        {
            return await GetAsQueryable()
                .Include(x => x.CompanyCategory)
                .Include(x => x.About)
                .Include(x => x.Blogs)
                .Include(x => x.MeetDates)
                .Where(x => x.AppUsers.Any(x => x.Id == userId))
                .FirstOrDefaultAsync();
        }
    }
}
