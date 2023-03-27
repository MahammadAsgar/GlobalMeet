using GlobalMeet.DataAccess.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class PrivacyPolicy : EntityBase
    {
        public string Terms { get; set; }
        public int PolicyTypeId { get; set; }
        public PolicyType PolicyType { get; set; }
    }
}
