using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class MeetService : IMeetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMeetDateRepository _meetDateRepository;
        public MeetService(IUnitOfWork unitOfWork, IMapper mapper, IMeetDateRepository meetDateRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _meetDateRepository = meetDateRepository;
        }

        public async Task<ServiceResult> AddMeet(AddMeetDateDto meetDateDto)
        {
            var meet = _mapper.Map<MeetDate>(meetDateDto);
            await _unitOfWork.Repository<MeetDate>().AddAsync(meet);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public Task<ServiceResult> DeleteMeet(int id)
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
            var meet = await _meetDateRepository.GetMeetDatesByUserStatus(userId,statusId);
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

        public Task<ServiceResult> UpdateMeet(AddMeetDateDto meetDateDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
