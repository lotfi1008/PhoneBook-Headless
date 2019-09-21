using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Common;
using PhoneBook.Core.Domain.Common.Contracts;
using PhoneBook.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Infrastractures.Dal.SqlServer.Common
{
    public class EFBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly PhoneBookDBContext _context;
        public EFBaseRepository(PhoneBookDBContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }
        public DbSet<TEntity> Entities { get; }

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableAsNoTracking =>Entities.AsNoTracking();

        public TEntity Add(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));

            var result=  Entities.Add(entity);
            if (saveNow)
                _context.SaveChanges();
            return result.Entity;
        }

        public void Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (_context.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);
        }

        public TEntity Delete(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                _context.SaveChanges();
            return entity;
        }

        public void Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = _context.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;
        }

        public TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public void LoadCollection<TProperty>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty) where TProperty : class
        {
            Attach(entity);
            var collection = _context.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                collection.Load();
        }

        public void LoadReference<TProperty>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, TProperty>> referenceProperty) where TProperty : class
        {
            Attach(entity);
            var reference = _context.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                 reference.Load();
        }

        public TEntity Update(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            var result =Entities.Update(entity);
            if (saveNow)
            {
                _context.SaveChanges(); 
            }
            return result.Entity;
        }
    }
}
