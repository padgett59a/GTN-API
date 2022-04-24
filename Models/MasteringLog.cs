using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class MasteringLog
    {
        public int mlID { get; set; }
        public int msID { get; set; }
        public int? mastererID { get; set; }
        public int sessionID { get; set; }
        public int statusID { get; set; }
        public DateTime? DatePaid { get; set; }
        public string Notes { get; set; }
        public decimal? StepPaymentAmount { get; set; }

        public virtual Person Masterer { get; set; }
        public virtual MasteringStep Ms { get; set; }
        public virtual Session Session { get; set; }
        public virtual Status Status { get; set; }
    }
}
