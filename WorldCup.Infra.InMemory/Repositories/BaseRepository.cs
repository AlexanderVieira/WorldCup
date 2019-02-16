using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.Domain.Interfaces;

namespace WorldCup.Infra.InMemory.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
