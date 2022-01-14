using POSOfferBox.BL.EngineCore.Abstract;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace POSOfferBox.BL.EngineCore.Concrete
{
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        private readonly IServiceProvider _Services;

        public BusinessEngineFactory(IServiceProvider services)
        {
            this._Services = services;
        }

        public T GetBusinessEngine<T>() where T : IBusinessEngine
        {
            //Import instance of T from the DI container
            return _Services.GetService<T>();
        }
    }
}
