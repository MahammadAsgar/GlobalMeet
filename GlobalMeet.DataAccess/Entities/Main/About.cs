﻿using GlobalMeet.DataAccess.Entities.Common;

namespace GlobalMeet.DataAccess.Entities.Main
{
    public class About : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AboutFile> AboutFiles { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public bool IsActive { get; set; }
    }
}
