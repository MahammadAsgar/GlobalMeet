using GlobalMeet.DataAccess.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class MeetType : EntityBase
    {
        public string TypeTitle { get; set; }
        public ICollection<MeetDate> MeetDates { get; set; }
    }
}
