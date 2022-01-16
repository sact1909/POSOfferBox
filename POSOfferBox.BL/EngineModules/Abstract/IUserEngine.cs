using POSOfferBox.BL.EngineCore.Abstract;
using POSOfferBox.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DTOs;

namespace POSOfferBox.BL.EngineModules.Abstract
{
    public interface IUserEngine : IBusinessEngine
    {
        Task createUserFromRegisterAsync(UserDTO UserData);
    }
}
