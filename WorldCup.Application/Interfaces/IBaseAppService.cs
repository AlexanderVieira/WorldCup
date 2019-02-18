using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.Application.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity Add(TEntity obj);
        bool Remove(long id);
        bool Update(TEntity obj);
        void Dispose();
    }
}
