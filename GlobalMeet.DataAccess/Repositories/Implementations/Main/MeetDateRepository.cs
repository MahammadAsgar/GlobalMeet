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
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<MeetDate>> GetMeetDatesByCompany(int companyId)
        {
            return await GetAsQueryable()
                .Include(x => x.Status)
                .Include(x => x.Category)
                //.Where(x => x.CategoryId == companyId)
                .ToListAsync();
        }

        public async Task<ICollection<MeetDate>> GetMeetDates()
        {
            return await GetAsQueryable()
                .Include(x => x.Status)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<ICollection<MeetDate>> GetMeetDatesByStatus(int statusId)
        {
            return await GetAsQueryable()
                .Include(x => x.Status)
                .Include(x => x.Category)
                .Where(x => x.StatusId == statusId)
                .ToListAsync();
        }

        public async Task<ICollection<MeetDate>> GetDatesInToday()
        {
            return await GetAsQueryable()
                .Include(x => x.Category)
                .Where(x => x.StatusId == 2)
                .ToListAsync();
        }
    }
}
