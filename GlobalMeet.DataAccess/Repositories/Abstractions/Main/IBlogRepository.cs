using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetBlog(int id);
        Task<ICollection<Blog>> GetBlogs();
        Task<ICollection<Blog>> GetBlogsByCompany(int companyid);
    }
}
