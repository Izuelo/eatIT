using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eatIT.Database.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {

        bool Any(Expression<Func<TEntity, bool>> expression);

        TEntity Add(TEntity entity);

        TEntity GetByParam(Expression<Func<TEntity, bool>> expression);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);
    }
}