using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class BlogFileRepository : GenericRepository<BlogFile>, IBlogFileRepsitory
    {
        public BlogFileRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }
    }
}
