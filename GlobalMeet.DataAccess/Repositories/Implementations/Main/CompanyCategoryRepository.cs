using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class CompanyCategoryRepository : GenericRepository<CompanyCategory>, ICompanyCategoryRepository
    {
        public CompanyCategoryRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<ICollection<CompanyCategory>> GetCompanyCategories()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<CompanyCategory> GetCompanyCategory(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
