using F= GlobalMeet.DataAccess.Entities.Main; 
using GlobalMeet.DataAccess.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Context
{
    public class GlobalMeetDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public GlobalMeetDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<F.File> Files { get; set; }
        public DbSet<BlogFile> BlogFiles { get; set; }
    }
}
