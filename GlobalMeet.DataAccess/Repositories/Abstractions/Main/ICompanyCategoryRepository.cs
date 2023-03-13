﻿using GlobalMeet.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface ICompanyCategoryRepository : IGenericRepository<CompanyCategory>
    {
        Task<CompanyCategory> GetCompanyCategory(int id);
        Task<ICollection<CompanyCategory>> GetCompanyCategories();
    }
}