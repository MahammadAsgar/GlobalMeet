using GlobalMeet.Business.Dtos.User.Get;

namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetOrderWithUserDto
    {
        public int Id { get; set; }
        public AppUserDto AppUser { get; set; }
        public GetMeetDateDto MeetDate { get; set; }
        public GetCompanyNameDto Company { get; set; }
    }
}
