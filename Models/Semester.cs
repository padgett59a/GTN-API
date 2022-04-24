using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Semester
    {
        public Semester()
        {
            SemesterExams = new HashSet<SemesterExam>();
        }

        public int semesterID { get; set; }
        public string SemesterCode { get; set; }
        public int langID { get; set; }
        public bool? TrxComplete { get; set; }
        public bool? MrxComplete { get; set; }

        public virtual Language Lang { get; set; }
        public virtual SemesterCore SemesterCodeNavigation { get; set; }
        public virtual ICollection<SemesterExam> SemesterExams { get; set; }
    }
}
