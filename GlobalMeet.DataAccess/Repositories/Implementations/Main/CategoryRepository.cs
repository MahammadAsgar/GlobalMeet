using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }
        public async Task<Category> GetCategory(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
