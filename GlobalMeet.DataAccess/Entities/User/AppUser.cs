using GlobalMeet.DataAccess.Entities.Main;
using Microsoft.AspNetCore.Identity;


namespace GlobalMeet.DataAccess.Entities.User
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public bool IsFree { get; set; }
        public decimal ConsultationCost { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
        public IEnumerable<MeetDate> MeetDates { get; set; }
        public IEnumerable<Profession> Professions { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
