using Microsoft.EntityFrameworkCore;
using POSOfferBox.Data.Entities;
using POSOfferBox.Repo.Core.Factory.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Concrete
{
    public class Repository
    {
    }
    public class Repository<TEntity> : RepositoryBase<TEntity, POSOFFERBOXDBContext> where TEntity : class, new()
    {
        public Repository(POSOFFERBOXDBContext context) : base(context) { }

    }
}
