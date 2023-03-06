using GlobalMeet.DataAccess.Entities.Main;


namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrder(int id);
        Task<ICollection<Order>> GetOrdersByUser(int userId);
        Task<ICollection<Order>> GetOrders();
    }
}
