using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class MasteringStep
    {
        public MasteringStep()
        {
            MasteringCustomPays = new HashSet<MasteringCustomPay>();
            MasteringLogs = new HashSet<MasteringLog>();
        }

        public int msID { get; set; }
        public string Step { get; set; }
        public string Notes { get; set; }
        public decimal? DefaultPayDollars { get; set; }

        public virtual ICollection<MasteringCustomPay> MasteringCustomPays { get; set; }
        public virtual ICollection<MasteringLog> MasteringLogs { get; set; }
    }
}
