using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class AspNetRoleClaim
    {
        public int ID { get; set; }
        public string RoleID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetRole Role { get; set; }
    }
}
