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
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResult> AddCompany(AddCompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            await _unitOfWork.Repository<Company>().AddAsync(company);
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
    }
}
