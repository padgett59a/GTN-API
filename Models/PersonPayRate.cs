using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class PersonPayRate
    {
        public int personPayRateID { get; set; }
        public int personID { get; set; }
        public int stepID { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public virtual Person Person { get; set; }
    }
}
