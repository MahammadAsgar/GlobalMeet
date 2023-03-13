using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMeetDateRepository _meetDateRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyRepository _companyRepository;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMeetDateRepository meetDateRepository, ICompanyRepository companyRepository, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _meetDateRepository = meetDateRepository;
            _userManager = userManager;
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResult> AddOrder(AddOrderDto orderDto, int userId)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.AppUserId = userId;
            order.IsActive = true;
            var meets = await _meetDateRepository.GetMeetDatesByCompany(order.CompanyId);
            var meet = meets.FirstOrDefault(x => x.Id == orderDto.MeetDateId);
            if (meet != null)
            {
                await _unitOfWork.Repository<Order>().AddAsync(order);
                meet.StatusId = 2;
                _unitOfWork.Repository<MeetDate>().Update(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false, "meetDate not found");
        }


        public async Task<ServiceResult> CancelOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order != null)
            {
                var meet = await _meetDateRepository.GetMeetDate(order.MeetDateId);
                meet.StatusId = 1;
                order.IsActive = false;
                _unitOfWork.Repository<Order>().Update(order);
                _unitOfWork.Repository<MeetDate>().Update(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetArchivedOrdersByUser(int userId)
        {
            var orders = await _orderRepository.GetArchivedOrdersByUser(userId);
            if (orders != null)
            {
                var response = _mapper.Map<Order>(orders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetNonJoinedOrderByUser(int userId)
        {
            var orders = await _orderRepository.GetNonJoinedOrderByUser(userId);
            if (orders != null)
            {
                var response = _mapper.Map<Order>(orders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order != null)
            {
                var response = _mapper.Map<GetOrderDto>(order);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            if (orders != null)
            {
                var response = _mapper.Map<ICollection<GetOrderDto>>(orders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetOrdersByUser(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUser(userId);
            if (orders != null)
            {
                var response = _mapper.Map<ICollection<GetOrderDto>>(orders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
