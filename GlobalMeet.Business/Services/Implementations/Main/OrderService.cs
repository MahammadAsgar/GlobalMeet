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
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMeetDateRepository _meetDateRepository;
        private readonly IArchivedMeetRepository _archivedMeetRepository;
        private readonly UserManager<AppUser> _userManager;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMeetDateRepository meetDateRepository,
            UserManager<AppUser> userManager, IArchivedMeetRepository archivedMeetRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _meetDateRepository = meetDateRepository;
            _userManager = userManager;
            _archivedMeetRepository = archivedMeetRepository;
        }


        public async Task<ServiceResult> AddOrder(AddOrderDto orderDto, int userId)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.AppUserId = userId;
            await _unitOfWork.Repository<Order>().AddAsync(order);
            var meet = await _meetDateRepository.GetMeetDate(orderDto.MeetDateId);
            meet.StatusId = 2;
            _unitOfWork.Repository<MeetDate>().Update(meet);
            _unitOfWork.Commit();
            return new ServiceResult(true);
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

        public async Task<ServiceResult> ArchivedOrder(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUser(userId);
            ArchivedMeet archivedMeet = await _archivedMeetRepository.GetArchivedMeetByUser(userId);
            if (archivedMeet == null)
            {
                archivedMeet = new ArchivedMeet();
                archivedMeet.AppUserId = userId;
                var meets = new List<MeetDate>();
                foreach (var item in orders)
                {
                    if (item.MeetDate.Day < DateTime.Now)
                    {
                        meets.Add(item.MeetDate);
                    }
                }
                archivedMeet.ArchivedMeetDates = meets;
                await _unitOfWork.Repository<ArchivedMeet>().AddAsync(archivedMeet);
            }
            else
            {
                var meets = new List<MeetDate>();
                foreach (var item in orders)
                {
                    if (item.MeetDate.Day < DateTime.Now)
                    {
                        meets.Add(item.MeetDate);
                    }
                }
                archivedMeet.ArchivedMeetDates = meets;
                _unitOfWork.Repository<ArchivedMeet>().Update(archivedMeet);
            }
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
