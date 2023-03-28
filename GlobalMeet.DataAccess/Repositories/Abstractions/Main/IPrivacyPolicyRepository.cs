using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IPrivacyPolicyRepository : IGenericRepository<PrivacyPolicy>
    {
        Task<PrivacyPolicy> GetPrivacyPolicyByType(int policyTypeId);
        Task<ICollection<PrivacyPolicy>> GetPrivacyPolicies();
    }
}
