using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class AspNetUserClaim
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
