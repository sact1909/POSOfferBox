using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Contract
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SaleId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
