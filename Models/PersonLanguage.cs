using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class PersonLanguage
    {
        public int personID { get; set; }
        public int langID { get; set; }

        public virtual Language Lang { get; set; }
        public virtual Person Person { get; set; }
    }
}
