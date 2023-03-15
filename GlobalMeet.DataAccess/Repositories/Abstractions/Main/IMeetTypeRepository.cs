using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeetTypeRepository : IGenericRepository<MeetType>
    {
        Task<MeetType> GetMeetType(int id);
        Task<ICollection<MeetType>> GetMeetTypes();
    }
}
