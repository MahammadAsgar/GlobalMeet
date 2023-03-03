using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class BlogFileRepository : GenericRepository<BlogFile>, IBlogFileRepsitory
    {
        public BlogFileRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }
    }
}
