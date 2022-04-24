using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class ExamTranslationLog
    {
        public int examtlID { get; set; }
        public int examtsID { get; set; }
        public int semexamID { get; set; }
        public int? translatorID { get; set; }
        public decimal? PaidAmount { get; set; }
        public string Notes { get; set; }
        public int? statusID { get; set; }
        public DateTime? DatePaid { get; set; }

        public virtual ExamTranslationStep Examts { get; set; }
        public virtual SemesterExam Semexam { get; set; }
        public virtual Status Status { get; set; }
        public virtual Person Translator { get; set; }
    }
}
