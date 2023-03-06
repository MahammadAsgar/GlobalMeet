using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Profession : EntityBase
    {
        public string ProfessionTitle { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
