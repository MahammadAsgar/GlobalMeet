using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class PrivacyPolicy : EntityBase
    {
        public string Terms { get; set; }
        public int PolicyTypeId { get; set; }
        public PolicyType PolicyType { get; set; }
    }
}
