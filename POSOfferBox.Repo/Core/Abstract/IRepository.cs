using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entityToInsert);

        Task AddRange(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entityToUpdate);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        TEntity GetByID(Expression<Func<TEntity, bool>> expression);
        Task RemoveAsync(TEntity entityToDelete);
        Task RemoveAsync(object entityToDelete);
        Task RemoveRange(List<TEntity> entityToDelete);
        bool IsExist(Expression<Func<TEntity, bool>> expression);
    }
}
