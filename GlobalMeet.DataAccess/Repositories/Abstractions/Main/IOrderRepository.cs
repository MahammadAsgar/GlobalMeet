using GlobalMeet.DataAccess.Entities.Main;


namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrder(int id);
        Task<ICollection<Order>> GetOrdersByUser(int userId);
        Task<ICollection<Order>> GetOrders();

        Task<ICollection<Order>> GetArchivedOrdersByUser(int userId);
        Task<ICollection<Order>> GetNonJoinedOrderByUser(int userId);

        Task<ICollection<Order>> GetOrdersByCompany(int companyId);
        Task<ICollection<Order>> GetArchivedOrdersByCompany(int companyId);
        Task<ICollection<Order>> GetNonJoinedOrdersByCompany(int companyId);
    }
}
