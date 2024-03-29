﻿using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<Blog> GetBlog(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.BlogFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Blog>> GetBlogs()
        {
            return await GetAsQueryable()
                 .Include(x => x.BlogFiles)
                 .ToListAsync();
        }

        public async Task<ICollection<Blog>> GetBlogsByCompany(int companyid)
        {
            return await GetAsQueryable()
                .Include(x => x.BlogFiles)
                .Where(x => x.CompanyId == companyid)
                .ToListAsync();
        }
    }
}
