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
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly UserManager<AppUser> _userManager;
        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork, ICompanyRepository companyRepository, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _userManager = userManager;
        }

        public async Task<ServiceResult> AddCompany(AddCompanyDto companyDto, int userId)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.IsActive = true;
            company.IsApproved = false;
            var user = _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            company.AppUsers = new List<AppUser>();
            company.AppUsers.Add(user.Result);
            await _unitOfWork.Repository<Company>().AddAsync(company);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }


        public async Task<ServiceResult> AddWorker(int userId, int workerId)
        {
            var company = await _companyRepository.GetCompanyByUser(userId);
            var worker= _userManager.Users.FirstOrDefaultAsync(x=>x.Id == workerId);
            company.AppUsers=new List<AppUser>();
            company.AppUsers.Add(worker.Result);
            _unitOfWork.Repository<Company>().Update(company);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            if (companies != null)
            {
                var response = _mapper.Map<ICollection<GetCompanyDto>>(companies);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetCompany(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            if (company != null)
            {
                var response = _mapper.Map<GetCompanyDto>(company);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> ApproveRequest(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            if (company != null)
            {
                company.IsApproved = true;
                _unitOfWork.Repository<Company>().Update(company);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetCompanyDto>(company);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
        public async Task<ServiceResult> RejectRequest(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            if (company != null)
            {
                company.IsActive = false;
                _unitOfWork.Repository<Company>().Update(company);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
