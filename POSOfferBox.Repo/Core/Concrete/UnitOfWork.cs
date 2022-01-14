using Microsoft.EntityFrameworkCore;
using POSOfferBox.Repo.Core.Abstract;
using POSOfferBox.Repo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        //public IMaestraPolizaRepository MaestraPolizaRepo => new MaestraPolizaRepository(_context);
        //public IUserRepository UserRepo => new UserRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<ResponseDTO> SaveAsync()
        {

            try
            {
                var rowsCount = await _context.SaveChangesAsync();

                return new ResponseDTO()
                {
                    OperationSuccess = true,
                    Message = "Los Datos fueron guardados correctamente",
                    Data = rowsCount
                };

            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    OperationSuccess = false,
                    Message = "Los Datos fueron guardados correctamente",
                    ExceptionError = ex
                };

            }

        }
    }
}
