using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IProfessionRepository : IGenericRepository<Profession>
    {
        Task<Profession> GetProfession(int id);
        Task<IEnumerable<Profession>> GetProfessions();
    }
}
