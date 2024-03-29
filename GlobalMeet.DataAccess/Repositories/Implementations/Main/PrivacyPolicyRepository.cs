﻿using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class PrivacyPolicyRepository : GenericRepository<PrivacyPolicy>, IPrivacyPolicyRepository
    {
        public PrivacyPolicyRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<ICollection<PrivacyPolicy>> GetPrivacyPolicies()
        {
            return await GetAsQueryable()
                 .ToListAsync();
        }

        public async Task<PrivacyPolicy> GetPrivacyPolicyByType(int policyTypeId)
        {
            return await GetAsQueryable()
                .Where(x => x.PolicyTypeId == policyTypeId)
                .FirstOrDefaultAsync();
        }
    }
}
