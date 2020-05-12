using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WM.Domain.Core.Models;

namespace WM.Domain.Cliente.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}