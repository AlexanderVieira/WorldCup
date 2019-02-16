using System.Collections.Generic;

namespace WorldCup.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface Repositorio Base criado para garantir
    /// as operações basicas estabelecendo um contrato generico
    /// @Autor: Alexander Silva
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity Add(TEntity obj);
        bool Remove(long id);
        bool Update(TEntity obj);
        void Dispose();
    }
}
