using System;
using System.Collections.Generic;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class User
    {
        public User()
        {
            UserHasRoles = new HashSet<UserHasRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<UserHasRole> UserHasRoles { get; set; }
    }
}
