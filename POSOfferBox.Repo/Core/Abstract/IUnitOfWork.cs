using POSOfferBox.Repo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Abstract
{
    public interface IUnitOfWork
    {
        Task<ResponseDTO> SaveAsync();
    }
}
