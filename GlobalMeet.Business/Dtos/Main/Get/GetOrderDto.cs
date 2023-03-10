namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public GetMeetDateDto MeetDate { get; set; }
        public GetCompanyNameDto Company { get; set; }
    }
}