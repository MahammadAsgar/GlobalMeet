using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Blog : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<BlogFile> BlogFiles { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
       // public IEnumerable<Tag> Tags { get; set; }
    }
}
