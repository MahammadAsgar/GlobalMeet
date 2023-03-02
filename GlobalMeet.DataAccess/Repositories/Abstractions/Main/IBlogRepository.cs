using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetBlog(int id);
        Task<IEnumerable<Blog>> GetBlogs();
        Task<IEnumerable<Blog>> GetBlogsByUser(int userId);
    }
}
