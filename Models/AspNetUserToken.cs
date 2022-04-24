using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class AspNetUserToken
    {
        public string UserID { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
