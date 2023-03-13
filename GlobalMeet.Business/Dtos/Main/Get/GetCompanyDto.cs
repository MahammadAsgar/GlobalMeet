using GlobalMeet.Business.Dtos.User.Get;
using GlobalMeet.DataAccess.Entities.Main;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetCompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<AppUser> AppUsers { get; set; }

        public GetCompanyCategoryDto CompanyCategory { get; set; }
        public GetAboutDto About { get; set; }
        public ICollection<GetMeetDateDto> MeetDates { get; set; }
        public ICollection<GetBlogDto> Blogs { get; set; }
    }
}
