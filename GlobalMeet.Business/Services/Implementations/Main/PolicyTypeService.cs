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
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPolicyTypeRepository _policyTypeRepository;
        public PolicyTypeService(IUnitOfWork unitOfWork, IMapper mapper, IPolicyTypeRepository policyTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _policyTypeRepository = policyTypeRepository;
        }

        public async Task<ServiceResult> AddPolicyType(AddPolicyTypeDto policyTypeDto)
        {
            var type = _mapper.Map<PolicyType>(policyTypeDto);
            await _unitOfWork.Repository<PolicyType>().AddAsync(type);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetPolicyType(int id)
        {
            var type = await _policyTypeRepository.GetPolicyType(id);
            if (type != null)
            {
                var response = _mapper.Map<GetPolicyTypeDto>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetPolicyTypes()
        {
            var type = await _policyTypeRepository.GetPolicyTypes();
            if (type != null)
            {
                var response = _mapper.Map<ICollection<GetPolicyTypeDto>>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdatePolicyType(AddPolicyTypeDto policyTypeDto, int id)
        {
            var type = await _policyTypeRepository.GetPolicyType(id);
            if (type != null)
            {
                if (!string.IsNullOrEmpty(policyTypeDto.Title))
                {
                    type.Title = policyTypeDto.Title;
                }
                _unitOfWork.Repository<PolicyType>().Update(type);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
