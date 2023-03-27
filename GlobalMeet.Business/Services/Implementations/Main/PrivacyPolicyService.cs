using AutoMapper;
using GlobalMeet.Business.Dtos.Main;
using GlobalMeet.Business.Dtos.Main.Get;
using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.UnitOfWorks;

namespace GlobalMeet.Business.Services.Implementations.Main
{
    public class PrivacyPolicyService : IPrivacyPolicyService
    {
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PrivacyPolicyService(IPrivacyPolicyRepository privacyPolicyRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _privacyPolicyRepository = privacyPolicyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> AddPrivacyPolicy(AddPrivacyPolicyDto privacyPolicyDto)
        {
            var policy = _mapper.Map<PrivacyPolicy>(privacyPolicyDto);
            await _unitOfWork.Repository<PrivacyPolicy>().AddAsync(policy);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetPrivacyPolicyDto>(policy);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPrivacyPolicies()
        {
            var policy = await _privacyPolicyRepository.GetPrivacyPolicies();
            if (policy != null)
            {
                var response = _mapper.Map<ICollection<GetPrivacyPolicyDto>>(policy);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetPrivacyPolicy(int typeId)
        {
            var policy = await _privacyPolicyRepository.GetPrivacyPolicyByType(typeId);
            if (policy != null)
            {
                var response = _mapper.Map<GetPrivacyPolicyDto>(policy);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdatePrivacyPolicy(AddPrivacyPolicyDto privacyPolicyDto, int typeId)
        {
            var policy = await _privacyPolicyRepository.GetPrivacyPolicyByType(typeId);
            if (policy != null)
            {
                if (!string.IsNullOrEmpty(privacyPolicyDto.Terms))
                {
                    policy.Terms = privacyPolicyDto.Terms;
                }
                _unitOfWork.Repository<PrivacyPolicy>().Update(policy);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetPrivacyPolicyDto>(policy);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
