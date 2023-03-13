using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IOrderService
    {
        Task<ServiceResult> AddOrder(AddOrderDto orderDto, int userId);
        Task<ServiceResult> CancelOrder(int id);
        Task<ServiceResult> GetOrder(int id);
        Task<ServiceResult> GetOrdersByUser(int userId);
        Task<ServiceResult> GetOrders();

        Task<ServiceResult> GetArchivedOrdersByUser(int userId);
        Task<ServiceResult> GetNonJoinedOrderByUser(int userId);
    }
}
