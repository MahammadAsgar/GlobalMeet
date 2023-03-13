using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Status : EntityBase
    {
        public string StatusTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
