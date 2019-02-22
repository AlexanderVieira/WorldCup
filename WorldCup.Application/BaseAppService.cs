using System;
using System.Collections.Generic;
using WorldCup.Application.Interfaces;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.Application
{
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseAppService(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        public TEntity Add(TEntity obj)
        {
            return _baseService.Add(obj);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseService.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _baseService.GetById(id);
        }

        public bool Remove(long id)
        {
            _baseService.Remove(id);
            return true;
        }

        public bool Update(TEntity obj)
        {
            _baseService.Update(obj);
            return true;
        }
    }
}
