using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class AspNetUserRole
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
