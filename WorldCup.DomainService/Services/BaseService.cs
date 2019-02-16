using System;
using System.Collections.Generic;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{
    public class BaseService<TEntity> : IDisposable, 
        IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add(TEntity obj)
        {
            return _baseRepository.Add(obj);            
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();            
        }

        public TEntity GetById(long id)
        {
            return _baseRepository.GetById(id);
        }

        public bool Remove(long id)
        {
            return _baseRepository.Remove(id);

        }

        public bool Update(TEntity obj)
        {
            return _baseRepository.Update(obj);
        }
    }
}
