using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalMeet.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddOrder([FromForm] AddOrderDto orderDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.AddOrder(orderDto, (int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> ApproveOrder(int id)
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.ApproveOrder(id);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> RejectOrder(int id)
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.RejectOrder(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrder(int id)
        {
            var response = await _orderService.GetOrder(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrders()
        {
            var response = await _orderService.GetOrders();
            return Ok(response);
        }



        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrdersByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetOrdersByUser((int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetArchivedOrdersByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetArchivedOrdersByUser((int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetNonJoinedOrderByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetNonJoinedOrderByUser((int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "Owner", "Moderator")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> CancelOrder(int id)
        {
            var response = await _orderService.CancelOrder(id);
            return Ok(response);
        }
    }
}