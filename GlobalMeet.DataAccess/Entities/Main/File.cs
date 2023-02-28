using GlobalMeet.DataAccess.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class File : EntityBase
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
