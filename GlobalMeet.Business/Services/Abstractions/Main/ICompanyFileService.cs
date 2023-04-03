using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface ICompanyFileService
    {
        Task<ServiceResult> AddRangeAsync(AddCompanyDto company, int companyId);
        Task<ServiceResult> UpdateRangeAsync(AddCompanyDto company, int companyId);
    }
}
