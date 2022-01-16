using POSOfferBox.Auth.ModelsAuth;
using POSOfferBox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Auth.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        //IEnumerable<User> GetAll();
        Task<User> GetUserByIdAsync(Guid id);

        string generateJwtToken(User user);
    }
}
