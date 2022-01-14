using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSOfferBox.Repo.Core.Factory.Abstract
{
    public interface IPagedList<T>
    {
        int TotalItemCount { get; set; }
        int Count { get; set; }
        int PageCount { get; set; }
        int CurrentPage { get; set; }
        T[] Data { get; set; }

        IPagedList<TResult> TransformData<TResult>(Func<IEnumerable<T>, IEnumerable<TResult>> transform);
    }
}
