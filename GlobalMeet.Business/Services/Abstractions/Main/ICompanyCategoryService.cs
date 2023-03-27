using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface ICompanyCategoryService
    {
        Task<ServiceResult> AddCompanyCategory(AddCompanyCategoryDto companyCategoryDto);
        Task<ServiceResult> UpdateCompanyCategory(AddCompanyCategoryDto companyCategoryDto, int id);
        Task<ServiceResult> GetCompanyCategory(int id);
        Task<ServiceResult> GetCompanyCategories();
    }
}
