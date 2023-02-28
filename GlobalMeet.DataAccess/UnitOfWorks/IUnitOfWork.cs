using GlobalMeet.DataAccess.Entities.Common;


namespace GlobalMeet.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;

        void Commit();
    }
}
