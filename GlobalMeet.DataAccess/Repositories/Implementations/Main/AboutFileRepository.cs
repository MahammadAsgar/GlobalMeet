using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class AboutFileRepository : GenericRepository<AboutFile>, IAboutFileRepository
    {
        public AboutFileRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }
    }
}
