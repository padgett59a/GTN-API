using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Status
    {
        public Status()
        {
            ExamTranslationLogs = new HashSet<ExamTranslationLog>();
            MasteringLogs = new HashSet<MasteringLog>();
            TranslationLogs = new HashSet<TranslationLog>();
        }

        public int statusID { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<ExamTranslationLog> ExamTranslationLogs { get; set; }
        public virtual ICollection<MasteringLog> MasteringLogs { get; set; }
        public virtual ICollection<TranslationLog> TranslationLogs { get; set; }
    }
}
