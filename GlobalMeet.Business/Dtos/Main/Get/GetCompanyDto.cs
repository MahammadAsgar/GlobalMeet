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
        public ICollection<GetBlogDto>? Blogs { get; set; }
    }
}
