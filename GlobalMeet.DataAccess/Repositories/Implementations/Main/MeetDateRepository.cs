using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class MeetDateRepository : GenericRepository<MeetDate>, IMeetDateRepository
    {
        public MeetDateRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<MeetDate> GetMeetDate(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<MeetDate> GetLastMeet()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<MeetDate>> GetMeetDates()
        {
            return await GetAsQueryable()
                .Include(x => x.Status)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetDate>> GetMeetDatesByStatus(int status)
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetDate>> GetMeetDatesByUser(int userId)
        {
            return await GetAsQueryable()
                  .Where(x => x.AppUserId == userId)
                .ToListAsync();
        }
        public async Task<MeetDate> GetMeetDateByUser(int userId, int id)
        {
            return await GetAsQueryable()
                .Where(x => x.AppUserId == userId)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MeetDate>> GetMeetDatesByUserStatus(int userId, int statusId)
        {
            return await GetAsQueryable()
                // .Where(x => x.AppUserId == userId && x.StatusId == statusId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetDate>> GetMeetDatesFree(int userId, bool isFree)
        {
            return await GetAsQueryable()
                 //  .Where(x => x.AppUserId == userId && x.AppUser.IsFree == isFree)
                 .ToListAsync();
        }
    }
}
