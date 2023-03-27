using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IPrivacyPolicyService
    {
        Task<ServiceResult> AddPrivacyPolicy(AddPrivacyPolicyDto privacyPolicyDto);
        Task<ServiceResult> UpdatePrivacyPolicy(AddPrivacyPolicyDto privacyPolicyDto, int TypeId);
        Task<ServiceResult> GetPrivacyPolicy(int typeId);
        Task<ServiceResult> GetPrivacyPolicies();
    }
}
