using System;
using System.Linq;
using System.Linq.Expressions;
using eatIT.Database.Repository.Interfaces;

namespace eatIT.Database.Repository.Classes
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DatabaseContext DatabaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public bool Any(Expression<Func<TEntity,bool>> expression)
        {
             return DatabaseContext.Set<TEntity>().Any(expression);
             
        }
        
        public TEntity Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
            DatabaseContext.SaveChanges();

            return entity;
        }
        
        public TEntity GetByParam(Expression<Func<TEntity, bool>> expression)
        {
            return DatabaseContext.Set<TEntity>().FirstOrDefault(expression);
             
        }

        public TEntity Update(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Update(entity);
            DatabaseContext.SaveChanges();

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
            DatabaseContext.SaveChanges();

            return entity;
        }
    }
}