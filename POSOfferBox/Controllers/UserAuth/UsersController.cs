using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.DTOs;

namespace POSOfferBox.Controllers.UserAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBusinessEngineFactory businessEngineFactory;
        private readonly IDataRepositoryFactory dataRepositoryFactory;
        public UsersController(IBusinessEngineFactory _businessEngineFactory, IDataRepositoryFactory _dataRepositoryFactory)
        {
            this.businessEngineFactory = _businessEngineFactory;
            this.dataRepositoryFactory = _dataRepositoryFactory;
        }


        [HttpPost("createuserfromregister")]
        public async Task<IActionResult> Authenticate(UserDTO model)
        {
            var productsEngine = businessEngineFactory.GetBusinessEngine<IUserEngine>();

            await productsEngine.createUserFromRegisterAsync(model);
            return Ok();

            //using (var transaction = dataRepositoryFactory.GetUnitOfWork().CreateTransaction())
            //{
                
            //    await transaction.CommitAsync();
                
            //}
        }

    }
}
