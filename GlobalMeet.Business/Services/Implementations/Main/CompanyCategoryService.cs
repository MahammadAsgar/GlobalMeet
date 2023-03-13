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
    public class CompanyCategoryService : ICompanyCategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyCategoryService(IMapper mapper, ICompanyCategoryRepository companyCategoryRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _companyCategoryRepository = companyCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> AddCompanyCategory(AddCompanyCategoryDto companyCategoryDto)
        {
            var companyCategory = _mapper.Map<CompanyCategory>(companyCategoryDto);
            await _unitOfWork.Repository<CompanyCategory>().AddAsync(companyCategory);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetCompanyCategories()
        {
            var categories = await _companyCategoryRepository.GetCompanyCategories();
            if (categories != null)
            {
                var response = _mapper.Map<ICollection<GetCompanyCategoryDto>>(categories);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetCompanyCategory(int id)
        {
            var category = await _companyCategoryRepository.GetCompanyCategory(id);
            if (category != null)
            {
                var response = _mapper.Map<GetCompanyCategoryDto>(category);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateCompanyCategory(AddCompanyCategoryDto companyCategoryDto, int id)
        {
            var category = await _companyCategoryRepository.GetCompanyCategory(id);
            if (category != null)
            {
                if (!string.IsNullOrEmpty(companyCategoryDto.Title))
                {
                    category.Title = companyCategoryDto.Title;
                }
                if (!string.IsNullOrEmpty(companyCategoryDto.Description))
                {
                    category.Description = companyCategoryDto.Description;
                }
                _unitOfWork.Repository<CompanyCategory>().Update(category);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
