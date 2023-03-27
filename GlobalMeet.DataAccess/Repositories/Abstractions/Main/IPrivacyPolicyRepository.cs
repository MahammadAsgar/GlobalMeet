using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IPrivacyPolicyRepository : IGenericRepository<PrivacyPolicy>
    {
        Task<PrivacyPolicy> GetPrivacyPolicyByType(int policyTypeId);
        Task<ICollection<PrivacyPolicy>> GetPrivacyPolicies();
    }
}
