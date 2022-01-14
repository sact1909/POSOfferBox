using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cedula { get; set; }
        public string Rnc { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
