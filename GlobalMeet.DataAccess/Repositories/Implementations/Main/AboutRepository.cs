﻿using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<About> GetAbout(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.AboutFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<About> GetAboutByCompany(int companyId)
        {
            return await GetAsQueryable()
                .Include(x => x.AboutFiles)
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<About>> GetAbouts()
        {
            return await GetAsQueryable()
                 .Include(x => x.AboutFiles)
                 .ToListAsync();
        }
    }
}
