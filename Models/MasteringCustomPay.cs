using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class MasteringCustomPay
    {
        public int mpID { get; set; }
        public int msID { get; set; }
        public int langID { get; set; }
        public decimal CustomPayDollars { get; set; }
        public string Notes { get; set; }
        public int? customPaySetID { get; set; }

        public virtual CustomPaySet CustomPaySet { get; set; }
        public virtual Language Lang { get; set; }
        public virtual MasteringStep Ms { get; set; }
    }
}
