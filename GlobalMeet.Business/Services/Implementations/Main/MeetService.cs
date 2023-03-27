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
        private readonly ICompanyRepository _companyRepository;
        public MeetService(IUnitOfWork unitOfWork, IMapper mapper, IMeetDateRepository meetDateRepository, UserManager<AppUser> userManager, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _meetDateRepository = meetDateRepository;
            _userManager = userManager;
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResult> AddMeet(AddMeetDateDto meetDateDto, int userId)
        {
            var meet = _mapper.Map<MeetDate>(meetDateDto);
            meet.StatusId = 1;
            meet.IsActive = true;
            meet.StatusId = 1;
            meet.IsActive = true;
            meet.Joined = false;
            var company = await _companyRepository.GetCompanyByUser(userId);
            meet.CompanyId = company.Id;
            await _unitOfWork.Repository<MeetDate>().AddAsync(meet);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }


        public async Task<ServiceResult> UserAddMeet(AddMeetDateDto meetDateDto, int userId)
        {
            var meets = await _meetDateRepository.GetMeetDates();
            bool isTrue= meets.Any(x=>x.Day== meetDateDto.Day&&x.StartDate==meetDateDto.StartDate&&x.EndDateDate==meetDateDto.EndDateDate&&x.CategoryId==meetDateDto.CategoryId);
            if (isTrue==false)
            {
                var meet = _mapper.Map<MeetDate>(meetDateDto);
                meet.StatusId = 1;
                meet.IsActive = true;
                meet.StatusId = 1;
                meet.IsActive = true;
                meet.Joined = false;
                var company = await _companyRepository.GetCompanyByUser(userId);
                meet.CompanyId = company.Id;
                await _unitOfWork.Repository<MeetDate>().AddAsync(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }


        public async Task<ServiceResult> DeleteMeet(int id)
        {
            var meet = await _meetDateRepository.GetMeetDate(id);
            if (meet != null)
            {
                meet.IsActive = false;
                _unitOfWork.Repository<MeetDate>().Update(meet);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
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

        public async Task<ServiceResult> GetMeetDatesByStatus(int statusId)
        {
            var meet = await _meetDateRepository.GetMeetDatesByStatus(statusId);
            if (meet != null)
            {
                var response = _mapper.Map<ICollection<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesByCompany(int companyId)
        {

            var meet = await _meetDateRepository.GetMeetDatesByCompany(companyId);
            if (meet != null)
            {
                var response = _mapper.Map<ICollection<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeetDatesByUserStatus(int companyId, int statusId)
        {
            var meet = await _meetDateRepository.GetMeetDatesByCompany(companyId);
            var meets = meet.Where(x => x.StatusId == statusId);
            if (meets != null)
            {
                var response = _mapper.Map<ICollection<GetMeetDateDto>>(meet);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeets()
        {
            var meet = await _meetDateRepository.GetMeetDates();
            if (meet != null)
            {
                var response = _mapper.Map<ICollection<GetMeetDateDto>>(meet);
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
            //    var meet = await _meetDateRepository.GetMeetDateByUser(userId, id);
            //    if (meet != null && meet.StatusId == 2)
            //    {
            //        meet.Joined = joined;
            //        _unitOfWork.Repository<MeetDate>().Update(meet);
            //        _unitOfWork.Commit();
            //        return new ServiceResult(true);
            //    }
            return new ServiceResult(false);
        }
    }
}
