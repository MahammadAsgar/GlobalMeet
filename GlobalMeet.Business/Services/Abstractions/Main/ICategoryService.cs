using GlobalMeet.Business.Dtos.Main.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.Main
{
    public interface ICategoryService
    {
        Task<ServiceResult> AddCategory(AddCategoryDto categoryDto);
        Task<ServiceResult> UpdateCategory(AddCategoryDto categoryDto, int id);
        Task<ServiceResult> DeleteCategory(int id);
        Task<ServiceResult> GetCategory(int id);
        Task<ServiceResult> GetCategories();
    }
}
