using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }

        public int CompanyCategoryId { get; set; }
        public CompanyCategory CompanyCategory { get; set; }

        // public int? AboutId { get; set; }
        public About About { get; set; }

        public ICollection<MeetDate>? MeetDates { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
