using Moq;
using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Controllers.ProducsControllers;
using POSOfferBox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace POSOfferBox.Test.ControllerTest
{
    public class ProductsControllerTest : TestBase<IProductsEngine>
    {

        private ProductsController _Controller;

        public ProductsControllerTest()
        {
            _Controller = new ProductsController(businessEngineFactory.Object);
        }


        [Fact]
        public async Task TestGetAllProducts()
        {

            var ProductsListObject = new List<Product> {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Producto One"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Producto Two"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Producto Three"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Producto Four"
                },
            };

            SetupEngine(a=>a.GetAllProductsAsync()).ReturnsAsync(ProductsListObject);
            var Products = await _Controller.GetAllProductsAsync();

            Assert.NotNull(Products);
            Assert.Equal(ProductsListObject.Count, Products.Count());
        }



        //[Fact]
        //public async Task TestGetAllProducts() 
        //{

        //    var ProductsListObject = new List<Product> {
        //        new Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Producto One"
        //        },
        //        new Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Producto Two"
        //        },
        //        new Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Producto Three"
        //        },
        //        new Product
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Producto Four"
        //        },
        //    };

        //    businessEngineFactory.Setup(a => a.GetBusinessEngine<IProductsEngine>().GetAllProducts()).ReturnsAsync(ProductsListObject);
        //    //businessEngineFactory.Setup(a => a.GetBusinessEngine<IProductsEngine>().GetAllProducts()).ReturnsAsync(ProductsListObject);

        //    var Products = await _Controller.GetAllProductsAsync();

        //    Assert.NotNull(Products);
        //    Assert.Equal(ProductsListObject.Count, Products.Count());
        //}

    }
}
