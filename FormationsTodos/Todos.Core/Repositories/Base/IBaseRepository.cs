using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Core.Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<int> Add(TEntity entity, String addedBy);
        Task<int> Update(TEntity entity, String updatedBy);
        Task Delete(int entityId, String deletedBy, bool physical = false);

        Task Delete(Expression<Func<TEntity, bool>> predicate, String deletedBy, bool physical = false);
        IQueryable<TEntity> FindAll(bool deletedItems, params string[] entitiesIncludes);
        Task<TEntity> FindById(int id, params string[] entitiesIncludes);
    }

}
