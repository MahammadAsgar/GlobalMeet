using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IPolicyTypeService
    {
        Task<ServiceResult> AddPolicyType(AddPolicyTypeDto policyTypeDto);
        Task<ServiceResult> GetPolicyType(int id);
        Task<ServiceResult> UpdatePolicyType(AddPolicyTypeDto policyTypeDto, int id);
        Task<ServiceResult> GetPolicyTypes();
    }
}
