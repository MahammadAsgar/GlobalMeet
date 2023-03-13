using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class CompanyCategory : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
