using POSOfferBox.Repo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Factory.Abstract
{
    public interface IDataRepositoryFactory
    {
        IDataRepository<TEntity> GetDataRepository<TEntity>() where TEntity : class, new();
        //IContigencyDataRepository<TEntity> GetContigencyDataRepository<TEntity>() where TEntity : class, new();
        TRepository GetCustomDataRepository<TRepository>() where TRepository : IDataRepository;
        IUnitOfWork GetUnitOfWork();
        IUnitOfWork GetUnitOfWork<T>() where T : IUnitOfWork;
    }
}
