using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class SemesterExam
    {
        public SemesterExam()
        {
            ExamTranslationLogs = new HashSet<ExamTranslationLog>();
        }

        public int semexamID { get; set; }
        public int semesterID { get; set; }
        public string SemesterCode { get; set; }
        public string Notes { get; set; }
        public bool IsFinalExam { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<ExamTranslationLog> ExamTranslationLogs { get; set; }
    }
}
