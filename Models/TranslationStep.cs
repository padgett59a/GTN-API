using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class TranslationStep
    {
        public TranslationStep()
        {
            TranslationCustomPays = new HashSet<TranslationCustomPay>();
            TranslationLogs = new HashSet<TranslationLog>();
        }

        public int tsID { get; set; }
        public string Step { get; set; }
        public string Notes { get; set; }
        public decimal? DefaultPayDollars { get; set; }

        public virtual ICollection<TranslationCustomPay> TranslationCustomPays { get; set; }
        public virtual ICollection<TranslationLog> TranslationLogs { get; set; }
    }
}
