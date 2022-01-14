using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class SaleStatus
    {
        public SaleStatus()
        {
            Sales = new HashSet<Sale>();
        }

        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
