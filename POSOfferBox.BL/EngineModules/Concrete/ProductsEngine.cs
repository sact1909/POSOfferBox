using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.BL.EngineModules.Concrete
{
    public class ProductsEngine : IProductsEngine
    {
        private readonly IDataRepositoryFactory dataRepositoryFactory;
        public ProductsEngine(IDataRepositoryFactory _dataRepositoryFactory)
        {
            this.dataRepositoryFactory = _dataRepositoryFactory;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productRepositoryFactory = dataRepositoryFactory.GetDataRepository<Product>();
            var result = await productRepositoryFactory.GetAllAsync();
            return result;
        }
    }
}
