using GlobalMeet.DataAccess.Entities.Common;


namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Blog : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<BlogFile> BlogFiles { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
