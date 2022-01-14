using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Stock
    {
        public Guid ProductId { get; set; }
        public decimal? InStock { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual Product Product { get; set; }
    }
}
