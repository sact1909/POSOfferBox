using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserHasRoles = new HashSet<UserHasRole>();
        }

        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<UserHasRole> UserHasRoles { get; set; }
    }
}
