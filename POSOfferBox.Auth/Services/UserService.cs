using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using POSOfferBox.Auth.Helpers;
using POSOfferBox.Auth.ModelsAuth;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo.Core.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.CrypHelpers;

namespace POSOfferBox.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly JWTSettings _appSettings;
        //protected readonly IUnitOfWork _unitofwork;
        protected readonly IDataRepositoryFactory _RepositoryFactory;

        private readonly IHashHelper hashHelper;

        public UserService(IOptions<JWTSettings> appSettings, IDataRepositoryFactory RepositoryFactory, IHashHelper _hashHelper)
        {
            _RepositoryFactory = RepositoryFactory;
            _appSettings = appSettings.Value;
            this.hashHelper = _hashHelper;
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var UserRepository = _RepositoryFactory.GetDataRepository<User>();

            var hashResult = await hashHelper.MD5(model.Password);

            var user = await UserRepository.GetAsync(x => x.Username == model.Username && x.Password == hashResult);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var UserRepository = _RepositoryFactory.GetDataRepository<User>();
            return await UserRepository.GetAsync(x => x.Id == id);
        }

        public string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
