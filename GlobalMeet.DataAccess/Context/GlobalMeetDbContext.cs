using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using F = GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Context
{
    public class GlobalMeetDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public GlobalMeetDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<F.File> Files { get; set; }
        public DbSet<BlogFile> BlogFiles { get; set; }
        public DbSet<MeetDate> MeetDates { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
