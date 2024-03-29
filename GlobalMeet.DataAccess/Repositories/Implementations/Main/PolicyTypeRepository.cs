﻿using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace GlobalMeet.DataAccess.Repositories.Implementations.Main
{
    public class PolicyTypeRepository : GenericRepository<PolicyType>, IPolicyTypeRepository
    {
        public PolicyTypeRepository(GlobalMeetDbContext globalMeetDbContext) : base(globalMeetDbContext)
        {
        }

        public async Task<PolicyType> GetPolicyType(int id)
        {
            return await GetAsQueryable()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<PolicyType>> GetPolicyTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
