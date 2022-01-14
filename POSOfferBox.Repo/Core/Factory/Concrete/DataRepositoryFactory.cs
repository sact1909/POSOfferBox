using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSOfferBox.Repo.Core.Abstract;

namespace POSOfferBox.Repo.Core.Factory.Concrete
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        private readonly IServiceProvider _Services;

        public DataRepositoryFactory() { }

        public DataRepositoryFactory(IServiceProvider services)
        {
            this._Services = services;
        }

        public IDataRepository<TEntity> GetDataRepository<TEntity>() where TEntity : class, new()
        {
            //Import instance of T from the DI container
            var instance = _Services.GetService<IDataRepository<TEntity>>();

            return instance;
        }

        public TRepository GetCustomDataRepository<TRepository>() where TRepository : IDataRepository
        {
            //Import instance of the repository from the DI container
            var instance = _Services.GetService<TRepository>();

            return instance;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            //Import instance of T from the DI container
            var instance = _Services.GetService<IUnitOfWork>();

            return instance;
        }

        public IUnitOfWork GetUnitOfWork<T>() where T : IUnitOfWork
        {
            //Import instance of T from the DI container
            var instance = _Services.GetService<T>();

            return instance;
        }

        //public IContigencyDataRepository<TEntity> GetContigencyDataRepository<TEntity>() where TEntity : class, new()
        //{
        //    var instance = _Services.GetService<IContigencyDataRepository<TEntity>>();

        //    return instance;
        //}
    }
}
