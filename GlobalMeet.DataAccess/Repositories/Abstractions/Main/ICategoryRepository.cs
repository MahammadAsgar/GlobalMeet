using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
