using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WM.Domain.Core.Models;

namespace WM.Domain.Anuncio.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();
    }
}