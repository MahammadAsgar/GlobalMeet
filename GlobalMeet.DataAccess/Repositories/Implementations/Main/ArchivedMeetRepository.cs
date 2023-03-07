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
    public class ArchivedMeetRepository : GenericRepository<ArchivedMeet>, IArchivedMeetRepository
    {
        public ArchivedMeetRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<ArchivedMeet> GetArchivedMeet(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.ArchivedMeetDates)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ArchivedMeet> GetArchivedMeetByUser(int userId)
        {
            return await GetAsQueryable()
                .Include(x => x.ArchivedMeetDates)
                .FirstOrDefaultAsync();
        }
    }
}
