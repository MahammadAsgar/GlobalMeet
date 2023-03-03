namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddMeetDateDto
    {
        public int Id { get; set; }
        public DateTime? Day { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDateDate { get; set; }
        public int? StatusId { get; set; }
    }
}
