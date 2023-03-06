using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
