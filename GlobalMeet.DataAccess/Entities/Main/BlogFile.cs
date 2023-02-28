using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class BlogFile : File
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
