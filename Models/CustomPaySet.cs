using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class CustomPaySet
    {
        public CustomPaySet()
        {
            MasteringCustomPays = new HashSet<MasteringCustomPay>();
            TranslationCustomPays = new HashSet<TranslationCustomPay>();
        }

        public int customPaySetID { get; set; }
        public string PaySetMonthYear { get; set; }
        public string PaySetType { get; set; }

        public virtual ICollection<MasteringCustomPay> MasteringCustomPays { get; set; }
        public virtual ICollection<TranslationCustomPay> TranslationCustomPays { get; set; }
    }
}
