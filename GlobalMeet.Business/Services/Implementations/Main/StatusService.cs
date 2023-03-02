using AutoMapper;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;


namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatusRepository _statusRepository;
        public StatusService(IUnitOfWork unitOfWork, IMapper mapper, IStatusRepository statusRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statusRepository = statusRepository;
        }
        public async Task<ServiceResult> AddStatus(AddStatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            await _unitOfWork.Repository<Status>().AddAsync(status);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> DeleteStatus(int id)
        {
            var status = await _statusRepository.GetStatus(id);
            if (status != null)
            {
                _unitOfWork.Repository<Status>().Delete(status);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetStatus(int id)
        {
            var status = await _statusRepository.GetStatus(id);
            if (status != null)
            {
                var response = _mapper.Map<GetStatusDto>(status);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetStatuses()
        {
            var statuses = await _statusRepository.GetStatuses();
            if (statuses != null)
            {
                var response = _mapper.Map<IEnumerable<GetStatusDto>>(statuses);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateStatus(AddStatusDto statusDto, int id)
        {
            var status = await _statusRepository.GetStatus(id);
            if (status != null)
            {
                if (!string.IsNullOrEmpty(statusDto.StatusTitle))
                {
                    status.StatusTitle = statusDto.StatusTitle;
                }
                _unitOfWork.Repository<Status>().Update(status);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
