using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetMeetTypeDto
    {
        public int Id { get; set; }
        public string TypeTitle { get; set; }
    }
}
