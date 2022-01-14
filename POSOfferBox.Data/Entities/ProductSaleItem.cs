using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class ProductSaleItem
    {
        public Guid Id { get; set; }
        public decimal? QuantitySold { get; set; }
        public decimal? PriceUnit { get; set; }
        public decimal? Price { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public Guid? SaleId { get; set; }
        public Guid? ProductId { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
