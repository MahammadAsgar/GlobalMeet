using GlobalMeet.DataAccess.Entities.Main;
using Microsoft.AspNetCore.Identity;


namespace GlobalMeet.DataAccess.Entities.User
{
    public class AppUser : IdentityUser<int>
    {
        public int Experience { get; set; }
        public int ConsultationCost { get; set; }
        public IEnumerable<MeetDate> MeetDates { get; set; }
    }
}
