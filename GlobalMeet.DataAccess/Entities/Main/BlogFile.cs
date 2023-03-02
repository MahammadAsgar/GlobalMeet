namespace GlobalMeet.DataAccess.Entities.Main
{
    public class BlogFile : File
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
