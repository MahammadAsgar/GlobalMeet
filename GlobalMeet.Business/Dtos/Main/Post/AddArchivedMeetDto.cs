using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddArchivedMeetDto
    {
        public int AppUserId { get; set; }
        public ICollection<int> ArchivedMeetDateIds { get; set; }
    }
}
