using Microsoft.EntityFrameworkCore;
using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Factory.Concrete
{
    public abstract class RepositoryBase<TEntity, U> : IDataRepository<TEntity>
        where TEntity : class, new()
        where U : DbContext
    {
        protected readonly U _Context;
        private readonly DbSet<TEntity> _DbSet;

        protected RepositoryBase(U context)
        {
            _Context = context;
            _DbSet = _Context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);

            _Context.SaveChanges();

            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _Context.Set<TEntity>().AddAsync(entity);

            await _Context.SaveChangesAsync();

            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entityList)
        {
            _Context.Set<TEntity>().AddRange(entityList);

            _Context.SaveChanges();

            return entityList;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entityList)
        {
            await _Context.Set<TEntity>().AddRangeAsync(entityList);

            await _Context.SaveChangesAsync();

            return entityList;
        }

        public virtual void Remove(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry<TEntity>(entity).State = EntityState.Deleted;

            _Context.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _DbSet.Attach(entity);

            _Context.Entry<TEntity>(entity).State = EntityState.Deleted;

            await _Context.SaveChangesAsync();
        }

        public virtual void RemoveAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity current in entities)
            {
                _DbSet.Attach(current);
                _Context.Entry<TEntity>(current).State = EntityState.Deleted;

            }

            _Context.SaveChanges();
        }

        public virtual async Task RemoveAllAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity current in entities)
            {
                _DbSet.Attach(current);
                _Context.Entry<TEntity>(current).State = EntityState.Deleted;

            }

            await _Context.SaveChangesAsync();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry<TEntity>(entity).State = EntityState.Modified;

            _Context.SaveChanges();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry<TEntity>(entity).State = EntityState.Modified;

            await _Context.SaveChangesAsync();

            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll(string sortExpression = null)
        {
            var query = _DbSet.AsNoTracking();

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return query.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string sortExpression = null)
        {
            var query = _DbSet.AsNoTracking();

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return await query.ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, string sortExpression = null)
        {
            var query = _DbSet.AsNoTracking().Where(filter);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return query.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, string sortExpression = null)
        {
            var query = _DbSet.AsNoTracking().Where(filter);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return await query.ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return notSortedResults.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return await notSortedResults.ToListAsync();
        }

        public virtual IEnumerable<TResult> GetAll<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return notSortedResults.ToList();
        }

        public virtual async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return await notSortedResults.ToListAsync();
        }

        public virtual IPagedList<TEntity> GetPaged(int pageIndex, int pageSize, string sortExpression = null)
        {
            var query = _DbSet.AsNoTracking();

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return new PagedList<TEntity>(query, pageIndex, pageSize);
        }

        public virtual async Task<IPagedList<TEntity>> GetPagedAsync(int pageIndex, int pageSize, string sortExpression = null)
        {
            return await Task.Run(() => this.GetPaged(pageIndex, pageSize, sortExpression));
        }

        public virtual IPagedList<TEntity> GetPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return new PagedList<TEntity>(notSortedResults, pageIndex, pageSize);
        }

        public virtual async Task<IPagedList<TEntity>> GetPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            return await Task.Run(() => this.GetPaged(transform, filter, pageIndex, pageSize, sortExpression));
        }

        public virtual IPagedList<TResult> GetPaged<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return new PagedList<TResult>(notSortedResults, pageIndex, pageSize);
        }

        public virtual async Task<IPagedList<TResult>> GetPagedAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            return await Task.Run(() => this.GetPaged(transform, filter, pageIndex, pageSize, sortExpression));
        }

        public virtual int GetCount<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            return transform(query).Count();
        }

        public virtual async Task<int> GetCountAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            return await transform(query).CountAsync();
        }

        [Obsolete("This method is obsolete, Use GetSingle Instead.")]
        public virtual TResult Get<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet : _DbSet.Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return notSortedResults.FirstOrDefault();
        }

        public virtual TResult GetSingle<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return notSortedResults.FirstOrDefault();
        }

        public virtual async Task<TResult> GetSingleAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var notSortedResults = transform(query);

            //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
            //and evaluation is different. Now, when you try to order by a property name string then it crashes.
            //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
            //and uncomment the line below.

            return await notSortedResults.FirstOrDefaultAsync();
        }

        //public virtual async Task<TResult> GetAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null)
        //{
        //    TResult result = await Task.Run(async () =>
        //    {
        //        var query = filter == null ? _DbSet : _DbSet.Where(filter);

        //        var notSortedResults = transform(query);

        //        //Breaking Changes in EF Core 3: The Query Translator for EF Core 3 was changed and the query building
        //        //and evaluation is different. Now, when you try to order by a property name string then it crashes.
        //        //If an update fixes this or a workaround is found, then implement it into the OrderBy Extension
        //        //and uncomment the line below.
        //        return await notSortedResults.FirstOrDefaultAsync();
        //    });

        //    return result;
        //}

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _Context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual bool Exists(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var result = transform(query);

            return result.Any();
        }

        public virtual async Task<bool> ExistsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var result = transform(query);

            return await result.AnyAsync();
        }

        public virtual bool Exists<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var result = transform(query);

            return result.Any();
        }

        public virtual async Task<bool> ExistsAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var result = transform(query);

            return await result.AnyAsync();
        }
    }
}
