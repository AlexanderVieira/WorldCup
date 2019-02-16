﻿using System.Collections.Generic;

namespace WorldCup.Domain.Interfaces
{
    /// <summary>
    /// Interface Repositorio Base criado para garantir
    /// as operações basicas estabelecendo um contrato generico
    /// @Autor: Alexander Silva
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(TEntity obj);
        void Add(TEntity obj);
        bool Remove(TEntity obj);
        bool Update(TEntity obj);
    }
}
