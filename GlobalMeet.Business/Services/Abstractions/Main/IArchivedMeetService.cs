using GlobalMeet.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface IArchivedMeetService
    {
        Task<ServiceResult> GetArchivedMeet(int id);
        Task<ServiceResult> GetArchivedMeetsByUser(int userId);
    }
}
