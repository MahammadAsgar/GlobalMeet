using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Order : EntityBase
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int MeetDateId { get; set; }
        public MeetDate MeetDate { get; set; }

        public bool IsActive { get; set; }
    }
}
