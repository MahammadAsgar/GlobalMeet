using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.User.Post
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public bool IsFree { get; set; }
        public decimal ConsultationCost { get; set; }
        public int AboutId { get; set; }
        public IEnumerable<int> MeetDateIds { get; set; }
        public IEnumerable<int> ProfessionIds { get; set; }
        public IEnumerable<int> BlogIds { get; set; }
    }
}
