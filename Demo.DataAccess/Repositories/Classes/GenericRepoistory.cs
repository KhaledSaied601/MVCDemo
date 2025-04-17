using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.SharedModels;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepoistory<TEntity>(AppDbContext _appDbContext) : IGenericRepoistory<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking) return _appDbContext.Set<TEntity>().Where(e=>e.IsDeleted!=true).ToList();
            else return _appDbContext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
        }



        //GetById
        public TEntity? GetById(int id)
        {
            return _appDbContext.Set<TEntity>().Find(id);
        }

        //Add
        public int Add(TEntity TEntity)
        {

            _appDbContext.Set<TEntity>().Add(TEntity);
            return _appDbContext.SaveChanges();

        }

        //Update
        public int Update(TEntity TEntity)
        {

            _appDbContext.Set<TEntity>().Update(TEntity);
            return _appDbContext.SaveChanges();

        }

        //Delete
        public int Remove(TEntity TEntity)
        {

            _appDbContext.Set<TEntity>().Remove(TEntity);
            return _appDbContext.SaveChanges();

        }


    }
}
