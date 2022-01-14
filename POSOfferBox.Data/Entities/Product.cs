using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductSaleItems = new HashSet<ProductSaleItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceUnit { get; set; }
        public string Sku { get; set; }
        public bool? AvailableStock { get; set; }
        public DateTime? RegisterDate { get; set; }
        public bool? Flag { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<ProductSaleItem> ProductSaleItems { get; set; }
    }
}
