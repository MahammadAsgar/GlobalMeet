using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class ArchivedMeet : EntityBase
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<MeetDate> ArchivedMeetDates { get; set; }
    }
}
