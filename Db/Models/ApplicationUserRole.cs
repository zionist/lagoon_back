using System;
using System.Collections.Generic;

namespace lagoon_back
{
    public partial class ApplicationUserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Userid { get; set; }

        public ApplicationUser User { get; set; }
    }
}
