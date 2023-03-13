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


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddOrder([FromForm] AddOrderDto orderDto)
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.AddOrder(orderDto, (int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrder(int id)
        {
            var response = await _orderService.GetOrder(id);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrders()
        {
            var response = await _orderService.GetOrders();
            return Ok(response);
        }



        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetOrdersByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetOrdersByUser((int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetArchivedOrdersByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetArchivedOrdersByUser((int)user.Data);
            return Ok(response);
        }


        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("User", "User")]
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetNonJoinedOrderByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _orderService.GetNonJoinedOrderByUser((int)user.Data);
            return Ok(response);
        }

        [CustomAuthorize("SuperAdmin", "SuperAdmin")]
        [CustomAuthorize("Admin", "Admin")]
        [CustomAuthorize("User", "User")]
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> CancelOrder(int id)
        {
            var response = await _orderService.CancelOrder(id);
            return Ok(response);
        }
    }
}