using System.Collections.Generic;

namespace WorldCup.DomainService.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity Add(TEntity obj);
        bool Remove(long id);
        bool Update(TEntity obj);
        void Dispose();
    }
}
