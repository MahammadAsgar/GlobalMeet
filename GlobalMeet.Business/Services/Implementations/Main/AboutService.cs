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
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly ICompanyRepository _companyRepository;
        public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IAboutRepository aboutRepository, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResult> AddAbout(AddAboutDto aboutDto, int userId)
        {
            var about = _mapper.Map<About>(aboutDto);
            about.IsActive = true;
            var company = await _companyRepository.GetCompanyByUser(userId);
            about.CompanyId = company.Id;
            await _unitOfWork.Repository<About>().AddAsync(about);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetAbout(int id)
        {
            var about = await _aboutRepository.GetAbout(id);
            if (about != null)
            {
                var response = _mapper.Map<GetAboutDto>(about);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetAboutByUser(int userId)
        {
            var company = await _companyRepository.GetCompanyByUser(userId);
            var about = await _aboutRepository.GetAboutByCompany(company.Id);
            if (about != null)
            {
                var response = _mapper.Map<GetAboutDto>(about);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetAbouts()
        {
            var abouts = await _aboutRepository.GetAbouts();
            if (abouts != null)
            {
                var response = _mapper.Map<ICollection<GetAboutDto>>(abouts);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateAbout(AddAboutDto aboutDto, int id)
        {
            var about = await _aboutRepository.GetAbout(id);
            if (about != null)
            {
                if (!string.IsNullOrEmpty(aboutDto.Title))
                {
                    about.Title = aboutDto.Title;
                }
                if (!string.IsNullOrEmpty(aboutDto.Description))
                {
                    about.Description = aboutDto.Description;
                }
                _unitOfWork.Repository<About>().Update(about);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
