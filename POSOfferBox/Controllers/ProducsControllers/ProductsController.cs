using Microsoft.AspNetCore.Mvc;
using POSOfferBox.Auth.Attributes;
using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSOfferBox.Controllers.ProducsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RolesAuth]
    public class ProductsController : ControllerBase
    {
        private readonly IBusinessEngineFactory businessEngineFactory;
        public ProductsController(IBusinessEngineFactory _businessEngineFactory)
        {
            this.businessEngineFactory = _businessEngineFactory;
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productsEngine = businessEngineFactory.GetBusinessEngine<IProductsEngine>();
            return await productsEngine.GetAllProductsAsync();
        }
    }
}
