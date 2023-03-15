using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IMeetTypeService
    {
        Task<ServiceResult> AddMeetType(AddMeetTypeDto meetTypeDto);
        Task<ServiceResult> GetMeetType(int id);
        Task<ServiceResult> GetMeetTypes();
    }
}
