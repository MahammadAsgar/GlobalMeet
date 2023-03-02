using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class About : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AboutFile> AboutFiles { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
