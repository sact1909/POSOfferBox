using POSOfferBox.BL.EngineModules.Abstract;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.CrypHelpers;
using Utilities.DTOs;

namespace POSOfferBox.BL.EngineModules.Concrete
{
    public class UserEngine : IUserEngine
    {
        private readonly IDataRepositoryFactory dataRepositoryFactory;
        private readonly IHashHelper hashHelper;
        public UserEngine(IDataRepositoryFactory _dataRepositoryFactory, IHashHelper _hashHelper)
        {
            this.dataRepositoryFactory = _dataRepositoryFactory;
            this.hashHelper = _hashHelper;
        }
        public async Task createUserFromRegisterAsync(UserDTO UserData)
        {
            var userRepositoryFactory = dataRepositoryFactory.GetDataRepository<User>();

            var hashResult = await hashHelper.MD5(UserData.Password);
            var resultEntity = new User()
            {
                Username = UserData.Username,
                Password = hashResult,
                Email = UserData.Email,
                Name = UserData.Name,
                RegisterDate = DateTime.UtcNow
            };

            await userRepositoryFactory.AddAsync(resultEntity);
        }
    }
}
