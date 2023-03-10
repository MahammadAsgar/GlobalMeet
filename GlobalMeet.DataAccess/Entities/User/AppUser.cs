using Microsoft.AspNetCore.Identity;


namespace GlobalMeet.DataAccess.Entities.User
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //admin
        // public int? Experience { get; set; }
        // public bool? IsFree { get; set; }
        //public decimal? ConsultationCost { get; set; }
        // public int? AboutId { get; set; }
        // public About? About { get; set; }
        //  public ICollection<MeetDate>? MeetDates { get; set; }
        //  public ICollection<Profession>? Professions { get; set; }
        // public ICollection<Blog>? Blogs { get; set; }

        ////user
        //public ICollection<MeetDate>? ReservedMeets { get; set; }
        // public ICollection<MeetDate>? ArchivedMeets { get; set; }
    }
}
