using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSOfferBox.Controllers.ProducsControllers
{
    [Route("api/[controller]")]
    [ApiController]
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
