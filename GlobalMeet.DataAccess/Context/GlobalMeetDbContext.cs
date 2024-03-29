﻿using GlobalMeet.DataAccess.Entities.Main;
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
        public DbSet<Category> Categories { get; set; }
        //public DbSet<CompanyFile> CompanyFiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<MeetType> MeetTypes { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
    }
}
