using System;
using System.Collections.Generic;

namespace lagoon_back
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            ApplicationUserRole = new HashSet<ApplicationUserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
