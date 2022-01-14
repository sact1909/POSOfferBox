using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.BL.EngineCore.Abstract
{
    public interface IBusinessEngine
    {
    }

    public interface IBusinessEngine<T> : IBusinessEngine
        where T : class, new()
    {

    }
}
