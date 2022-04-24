using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class TranslationCustomPay
    {
        public int tpID { get; set; }
        public int tsID { get; set; }
        public int langID { get; set; }
        public decimal CustomPayDollars { get; set; }
        public string Notes { get; set; }
        public int? customPaySetID { get; set; }

        public virtual CustomPaySet CustomPaySet { get; set; }
        public virtual Language Lang { get; set; }
        public virtual TranslationStep Ts { get; set; }
    }
}
