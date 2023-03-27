using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class MeetType : EntityBase
    {
        public string TypeTitle { get; set; }
        public ICollection<MeetDate> MeetDates { get; set; }
    }
}
