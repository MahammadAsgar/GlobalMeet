using GlobalMeet.DataAccess.Entities.Common;
using GlobalMeet.DataAccess.Repositories;

namespace GlobalMeet.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;

        void Commit();
    }
}
