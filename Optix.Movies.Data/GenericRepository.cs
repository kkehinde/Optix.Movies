using Microsoft.EntityFrameworkCore;
using Optix.Movies.Data.Extensions;
using System.Linq.Expressions;

namespace Optix.Movies.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        // Constructor
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> AllMatch(Expression<Func<TEntity, bool>> filter = null!,
                                                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
                                                                                          Expression<Func<TEntity, object>>[] paths = null!)
        {

            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            if (paths != null)
                query = query.IncludeMultiple(paths);

            if (orderBy != null)
                return orderBy(query);

            return query;
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null!, Expression<Func<TEntity, object>>[] paths = null!)
        {
            IQueryable<TEntity> query = dbSet;

            if (paths != null)
                query = query.IncludeMultiple(paths);

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public virtual TEntity FindById(object id)
        {
            return dbSet.Find(id)!;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id)!;
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] paths = null!)
        {
            IQueryable<TEntity> query = dbSet;

            if (paths != null)
                query = query.IncludeMultiple(paths);

            return query.FirstOrDefault<TEntity>(filter)!;
        }

    }

}
