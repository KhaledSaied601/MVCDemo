using Demo.DataAccess.Models.SharedModels;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepoistory<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity TEntity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity? GetById(int id);
        int Remove(TEntity TEntity);
        int Update(TEntity TEntity);
    }
}
