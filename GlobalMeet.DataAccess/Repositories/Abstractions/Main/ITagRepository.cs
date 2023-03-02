using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.DataAccess.Repositories.Abstractions.Main
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<Tag> GetTag(int id);
        Task<IEnumerable<Tag>> GetTags();
    }
}
