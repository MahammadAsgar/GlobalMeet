using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;


namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<Order> GetOrder(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.MeetDate)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await GetAsQueryable()
                .Include(x => x.MeetDate)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrdersByUser(int userId)
        {
            return await GetAsQueryable()
                .Include(x => x.MeetDate)
                .Where(x => x.AppUserId == userId)
                .ToListAsync();
        }


        public async Task<ICollection<Order>> GetArchivedOrdersByUser(int userId)
        {
            return await GetAsQueryable()
                .Where(x => x.AppUserId == userId && x.MeetDate.Day < DateTime.Now)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetNonJoinedOrderByUser(int userId)
        {
            return await GetAsQueryable()
                 .Where(x => x.AppUserId == userId && x.MeetDate.Day > DateTime.Now)
                .ToListAsync();
        }
    }
}
