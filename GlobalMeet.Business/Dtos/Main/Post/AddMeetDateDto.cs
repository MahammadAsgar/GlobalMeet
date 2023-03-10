namespace GlobalMeet.Business.Dtos.Main.Post
{
    public class AddMeetDateDto
    {
        public DateTime? Day { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDateDate { get; set; }
        public int CategoryId { get; set; }
        public decimal ConsultationCost { get; set; }
    }
}
