using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class MeetDate : EntityBase
    {
        public DateTime Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public bool IsActive { get; set; }
    }
    public class Status : EntityBase
    {
        public string StatusTitle { get; set; }
    }
}
