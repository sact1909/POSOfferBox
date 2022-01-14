using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            Contracts = new HashSet<Contract>();
            ProductSaleItems = new HashSet<ProductSaleItem>();
        }

        public Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? TaxAmount { get; set; }
        public Guid? SaleStatusId { get; set; }
        public Guid? UserHasRoleId { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual SaleStatus SaleStatus { get; set; }
        public virtual UserHasRole UserHasRole { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<ProductSaleItem> ProductSaleItems { get; set; }
    }
}
