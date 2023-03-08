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
    public class MeetService : IMeetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMeetDateRepository _meetDateRepository;
        private readonly UserManager<AppUser> _userManager;
        public MeetService(IUnitOfWork unitOfWork, IMapper mapper, IMeetDateRepository meetDateRepository, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _meetDateRepository = meetDateRepository;
            _userManager = userManager;
        }

        public async Task<ServiceResult> AddMeet(AddMeetDateDto meetDateDto, int userId)
        {
            var meet = _mapper.Map<MeetDate>(meetDateDto);
            meet.StatusId = 1;
            meet.IsActive = true;
            meet.AppUserId = userId;
            await _unitOfWork.Repository<MeetDate>().AddAsync(meet);

            var newMeet = await _meetDateRepository.GetMeetDate(meet.Id);
            //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            //var list = new List<MeetDate>();
            //list.Add(meet);
            //user.MeetDates = list;

            //var result = await _userManager.UpdateAsync(user);
            _unitOfWork.Commit();
            //if (result.Succeeded)
            //{
            //    return new ServiceResult(true);
            //}
            return new ServiceResult(true);
        }

        public Task<ServiceResult> DeleteMeet(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetMeet(int id)
        {
            var meet = await _meetDateRepository.GetMeetDate(id);
            if (meet != null)
            {
                var response = _mapper.Map<GetMeetDateDto>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesByStatus(int status)
        {
            var meet = await _meetDateRepository.GetMeetDatesByStatus(status);
            if (meet != null)
            {
                var response = _mapper.Map<IEnumerable<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesByUser(int userId)
        {
            var meet = await _meetDateRepository.GetMeetDatesByUser(userId);
            if (meet != null)
            {
                var response = _mapper.Map<IEnumerable<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesByUserStatus(int userId, int statusId)
        {
            var meet = await _meetDateRepository.GetMeetDatesByUserStatus(userId, statusId);
            if (meet != null)
            {
                var response = _mapper.Map<IEnumerable<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesFree(int userId, bool isFree)
        {
            var meet = await _meetDateRepository.GetMeetDatesFree(userId, isFree);
            if (meet != null)
            {
                var response = _mapper.Map<IEnumerable<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeets()
        {
            var meet = await _meetDateRepository.GetMeetDates();
            if (meet != null)
            {
                var response = _mapper.Map<IEnumerable<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }


        //Admin
        public async Task<ServiceResult> UpdateMeet(AddMeetDateDto meetDateDto, int id, int userId)
        {
            var meet = await _meetDateRepository.GetMeetDate(id);
            if (meet != null)
            {
                if (meetDateDto.Day.HasValue)
                {
                    meet.Day = meetDateDto.Day.Value;
                }

                if (meetDateDto.StartDate.HasValue)
                {
                    meet.StartDate = meetDateDto.StartDate.Value;
                }

                if (meetDateDto.EndDateDate.HasValue)
                {
                    meet.EndDateDate = meetDateDto.EndDateDate.Value;
                }

                //if (meetDateDto.StatusId.HasValue)
                //{
                //    meet.StatusId = meetDateDto.StatusId.Value;
                //}
                _unitOfWork.Repository<MeetDate>().Update(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> ChangeJoined(int userId, int id, bool joined)
        {
            var meet = await _meetDateRepository.GetMeetDateByUser(userId, id);
            if (meet != null && meet.StatusId == 2)
            {
                meet.Joined = joined;
                _unitOfWork.Repository<MeetDate>().Update(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }


        //Admin And User
        //public async Task<ServiceResult> ReserveMeet(UserReserveMeetDto userReserveMeetDto, int userId, int meetOwnUserId)
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //    var meets = await _meetDateRepository.GetMeetDatesByUser(meetOwnUserId);

        //    foreach (var item1 in meets)
        //    {
        //        foreach (var item2 in userReserveMeetDto.ReservedMeetIds)
        //        {
        //            if (item1.Id == item2)
        //            {
        //                item1.StatusId = 2;
        //               // user.ReservedMeets.Add(item1);
        //                _unitOfWork.Repository<MeetDate>().Update(item1);
        //                _unitOfWork.Commit();
        //            }
        //        }
        //    }
        //    // user.ReservedMeets = (await _unitOfWork.Repository<MeetDate>().GetAllAsync(x => userReserveMeetDto.ReservedMeets.Contains(x.Id))).ToList();
        //    var result = await _userManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        return new ServiceResult(true);
        //    }
        //    return new ServiceResult(false);
        //}

    }
}
