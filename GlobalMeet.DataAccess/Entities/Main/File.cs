using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class File : EntityBase
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
