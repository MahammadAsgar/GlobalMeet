using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class AboutFile:File
    {
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
