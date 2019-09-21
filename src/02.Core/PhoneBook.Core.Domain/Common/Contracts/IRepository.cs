using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Core.Domain.Common.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableAsNoTracking { get; }

        TEntity Add(TEntity entity, bool saveNow = true);

        void Attach(TEntity entity);

        TEntity Delete(TEntity entity, bool saveNow = true);
        
        void Detach(TEntity entity);

        TEntity GetById(params object[] ids);
        void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty) where TProperty : class;
        void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty) where TProperty : class;
        TEntity Update(TEntity entity, bool saveNow = true);

    }
}
