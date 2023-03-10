using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class MeetDate : EntityBase
    {
        public DateTime Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public bool IsActive { get; set; }
        public bool Joined { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public decimal? ConsultationCost { get; set; }
    }
    public class Status : EntityBase
    {
        public string StatusTitle { get; set; }
    }
}
