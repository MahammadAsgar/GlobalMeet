using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<Profession> GetProfession(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Profession>> GetProfessions()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
