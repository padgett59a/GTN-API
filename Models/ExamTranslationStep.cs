using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class ExamTranslationStep
    {
        public ExamTranslationStep()
        {
            ExamTranslationLogs = new HashSet<ExamTranslationLog>();
        }

        public int examtsID { get; set; }
        public string Step { get; set; }
        public decimal? DefaultPayDollars { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<ExamTranslationLog> ExamTranslationLogs { get; set; }
    }
}
