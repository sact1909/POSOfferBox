using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class UserHasRole
    {
        public UserHasRole()
        {
            Sales = new HashSet<Sale>();
        }

        public Guid Id { get; set; }
        public DateTime? RoleStartTime { get; set; }
        public DateTime? RoleEndTime { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
