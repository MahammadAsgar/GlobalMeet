namespace GlobalMeet.Business.Dtos.Main.Get
{
    public class GetMeetDateDto
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateDate { get; set; }
        public GetStatusDto Status { get; set; }
    }
}
