﻿using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Entities.User;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class Company : EntityBase
    {
        public int TempId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public int CompanyCategoryId { get; set; }
        public CompanyCategory CompanyCategory { get; set; }
        public About About { get; set; }
        public ICollection<MeetDate>? MeetDates { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        //public IEnumerable<CompanyFile> CompanyFiles { get; set; }

        //public string CompanyPhone { get; set; }
        //public string CompanyEmail { get; set; }
        //public string CompanyAdress { get; set; }
    }
}
