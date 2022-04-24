using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class TranslationLog
    {
        public int tlID { get; set; }
        public int tsID { get; set; }
        public int sessionID { get; set; }
        public int statusID { get; set; }
        public DateTime? DatePaid { get; set; }
        public string Notes { get; set; }
        public int? translatorID { get; set; }
        public decimal? StepPaymentAmount { get; set; }

        public virtual Session Session { get; set; }
        public virtual Status Status { get; set; }
        public virtual Person Translator { get; set; }
        public virtual TranslationStep Ts { get; set; }
    }
}
