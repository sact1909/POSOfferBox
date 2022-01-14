using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSOfferBox.BL.EngineModules.Abstract
{
    public interface IProductsEngine : IBusinessEngine
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
