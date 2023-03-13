using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface ICompanyService
    {
        Task<ServiceResult> AddCompany(AddCompanyDto companyDto);
        Task<ServiceResult> GetCompany(int id);
        Task<ServiceResult> GetCompanies();
    }
}
