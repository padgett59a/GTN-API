using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTN_API.Models
{
    public class TxSemester
    {
        [Key] //not really needed but avoids errors
        public Int32 LangID { get; set; }
        public string SemesterCode { get; set; }
        public string CourseCodes { get; set; }
        public int GenExams { get; set; }
    }
}
