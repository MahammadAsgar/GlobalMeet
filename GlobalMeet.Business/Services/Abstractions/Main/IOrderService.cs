using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IOrderService
    {
        Task<ServiceResult> AddOrder(AddOrderDto orderDto, int userId);
        Task<ServiceResult> CancelOrder(int id, int userId);
        Task<ServiceResult> GetOrder(int id);
        Task<ServiceResult> GetOrdersByUser(int userId);
        Task<ServiceResult> GetOrders();

        Task<ServiceResult> GetArchivedOrdersByUser(int userId);
        Task<ServiceResult> GetNonJoinedOrderByUser(int userId);
    }
}
