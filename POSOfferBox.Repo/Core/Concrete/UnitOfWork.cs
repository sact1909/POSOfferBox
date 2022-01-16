using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POSOfferBox.Repo.Core.Abstract;
using POSOfferBox.Repo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly DbContext _context;
        // Track whether Dispose has been called.
        private bool _Disposed = false;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        //public IMaestraPolizaRepository MaestraPolizaRepo => new MaestraPolizaRepository(_context);
        //public IUserRepository UserRepo => new UserRepository(_context);

        public void Dispose()
        {
            //_context.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbContextTransaction CreateTransaction()
        {
            return this._context.Database.BeginTransaction();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing && _context != null)
                {
                    _context.Dispose();
                }

                _Disposed = true;
            }
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
