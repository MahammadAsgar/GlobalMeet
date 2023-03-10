using GlobalMeet.Business.Dtos.User.Get;

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUserDto> AppUsers { get; set; }
        public GetCompanyCategoryDto CompanyCategory { get; set; }
        public GetAboutDto About { get; set; }
        public ICollection<GetMeetDateDto>? MeetDates { get; set; }
        public ICollection<GetBlogDto>? Blogs { get; set; }
    }
}
