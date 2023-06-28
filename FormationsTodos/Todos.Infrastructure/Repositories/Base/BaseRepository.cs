using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities;
using Todos.Core.Repositories.Base;
using Todos.Infrastructure.Data;

namespace Todos.Infrastructure.Repositories.Base
{
    internal class BaseEntityFrameworkRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContexte _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseEntityFrameworkRepository(DataBaseContexte dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<int> Add(TEntity entity, string addedBy)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var entityWithAuditing = entity as AuditableEntity;
            if (entityWithAuditing != null)
            {
                if (string.IsNullOrEmpty(addedBy))
                    throw new ArgumentNullException(nameof(addedBy));
                var dt = DateTime.UtcNow;
                entityWithAuditing.CreatedOn = dt;
                entityWithAuditing.CreatedBy = addedBy;
                entityWithAuditing.UpdatedOn = dt;
                entityWithAuditing.UpdatedBy = addedBy;
            }

            _dbSet.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity, string updatedBy)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityWithAuditing = entity as AuditableEntity;
            if (entityWithAuditing != null)
            {
                if (string.IsNullOrEmpty(updatedBy))
                    throw new ArgumentNullException(nameof(updatedBy));

                entityWithAuditing.UpdatedOn = DateTime.UtcNow;
                entityWithAuditing.UpdatedBy = updatedBy;

            }
            _dbSet.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int entityId, string deletedBy, bool physical = false)
        {
            if (string.IsNullOrEmpty(deletedBy))
                throw new ArgumentNullException(nameof(deletedBy));

            var entity = await FindById(entityId);

            if (physical)
                _dbSet.Remove(entity);
            else
            {
                var entityWithAuditing = entity as AuditableEntity;
                if (entityWithAuditing != null)
                {
                    entityWithAuditing.DeletedOn = DateTime.UtcNow;
                    entityWithAuditing.DeletedBy = deletedBy;
                    _dbSet.Update(entity);
                }
                else
                {
                    _dbSet.Remove(entity);
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Expression<Func<TEntity, bool>> predicate, string deletedBy, bool physical = false)
        {
            if (string.IsNullOrEmpty(deletedBy))
                throw new ArgumentNullException(nameof(deletedBy));

            var entitiesToDelete = await FindAll(deletedItems: false).Where(predicate).ToListAsync();

            foreach (var entity in entitiesToDelete)
            {
                if (physical)
                    _dbSet.Remove(entity);
                else
                {
                    var entityWithAuditing = entity as IAuditableEntity;
                    if (entityWithAuditing != null)
                    {
                        entityWithAuditing.DeletedOn = DateTime.UtcNow;
                        entityWithAuditing.DeletedBy = deletedBy;
                        _dbSet.Update(entity);
                    }
                    else
                    {
                        _dbSet.Remove(entity);
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> FindAll(bool deletedItems, params string[] entitiesIncludes)
        {
            IQueryable<TEntity> result = _dbSet;

            if (!deletedItems && typeof(IAuditableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                result = result.AsNoTracking().Where(x => ((IAuditableEntity)x).DeletedOn == null);
            }

            foreach (var entityInclude in entitiesIncludes)
            {
                result = result.Include(entityInclude);
            }

            return result;
        }

        public async Task<TEntity> FindById(int id, params string[] entitiesIncludes)
        {
            IQueryable<TEntity> query = FindAll(false, entitiesIncludes);
            // Récupérer la clé primaire de l'entité
            var keyName = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            // Créer une expression lambda pour filtrer par clé primaire
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, keyName);
            var constant = Expression.Constant(id);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

            // Exécuter la requête
            return await query.FirstOrDefaultAsync(lambda);

        }
    }
}
