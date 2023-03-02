namespace GlobalMeet.DataAccess.Entities.Main
{
    public class AboutFile : File
    {
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
