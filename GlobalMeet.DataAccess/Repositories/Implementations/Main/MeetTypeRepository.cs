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
    public class MeetTypeRepository : GenericRepository<MeetType>, IMeetTypeRepository
    {
        public MeetTypeRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<MeetType> GetMeetType(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<MeetType>> GetMeetTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
