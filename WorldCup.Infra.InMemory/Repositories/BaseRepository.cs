using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Interfaces;
using WorldCup.Infra.InMemory.Context;

namespace WorldCup.Infra.InMemory.Repositories
{
    /// <summary>
    /// Repositorio base generico que implementa a interface
    /// base generica
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IDisposable, 
        IBaseRepository<TEntity> where TEntity : class
    {
        private readonly WorldCupContext _ctx;

        public BaseRepository(WorldCupContext context)
        {
            _ctx = context;
        }
        public TEntity Add(TEntity obj)
        {
            _ctx.Set<TEntity>().Add(obj);
            _ctx.SaveChanges();
            return obj;            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>().ToList();            
        }

        public TEntity GetById(long id)
        {
            return _ctx.Set<TEntity>().Find(id);            
        }

        public bool Remove(long id)
        {
            var obj = _ctx.Set<TEntity>().Find(id);
            _ctx.Set<TEntity>().Remove(obj);
            _ctx.SaveChanges();
            return true;
        }

        public bool Update(TEntity obj)
        {
            _ctx.Entry<TEntity>(obj).State = EntityState.Modified;
            _ctx.SaveChanges();
            return true;            
        }
    }
}
