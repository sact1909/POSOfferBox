using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Factory.Abstract
{
    public interface IDataRepository
    {
    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, new()
    {
        T Add(T entity);

        Task<T> AddAsync(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entityList);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entityList);

        void RemoveAll(IEnumerable<T> entities);

        Task RemoveAllAsync(IEnumerable<T> entities);

        void Remove(T entity);

        Task RemoveAsync(T entity);

        T Update(T entity);

        Task<T> UpdateAsync(T entity);

        IEnumerable<T> GetAll(string sortExpression = null);

        Task<IEnumerable<T>> GetAllAsync(string sortExpression = null);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string sortExpression = null);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string sortExpression = null);

        IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        IEnumerable<TResult> GetAll<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        IPagedList<T> GetPaged(int pageIndex, int pageSize, string sortExpression = null);

        Task<IPagedList<T>> GetPagedAsync(int pageIndex, int pageSize, string sortExpression = null);

        IPagedList<T> GetPaged(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null);

        Task<IPagedList<T>> GetPagedAsync(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null);

        IPagedList<TResult> GetPaged<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null);

        Task<IPagedList<TResult>> GetPagedAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null);

        int GetCount<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);

        Task<int> GetCountAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);

        TResult Get<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        TResult GetSingle<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        Task<TResult> GetSingleAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        //Task<TResult> GetAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, string sortExpression = null);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        bool Exists<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);

        Task<bool> ExistsAsync<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);

        bool Exists(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);

        Task<bool> ExistsAsync(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);
    }
}
