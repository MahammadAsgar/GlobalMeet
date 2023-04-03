using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface ICompanyService
    {
        Task<ServiceResult> AddCompany(AddCompanyDto companyDto, int userId);
        Task<ServiceResult> GetCompany(int id);
        Task<ServiceResult> GetCompanies();
        Task<ServiceResult> RejectRequest(int id);
        Task<ServiceResult> ApproveRequest(int id);
        Task<ServiceResult> AddWorker(int userId, int workerId);

        Task<ServiceResult> GetActiveCompanies();
        Task<ServiceResult> DeActiveCompany(int id);
        Task<ServiceResult> ActivateCompany(int id);
    }
}
