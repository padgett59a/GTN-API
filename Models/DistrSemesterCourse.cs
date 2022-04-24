using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class DistrSemesterCourse
    {
        public string LangName { get; set; }
        public int langID { get; set; }
        public string SemesterName { get; set; }
        public string CourseName { get; set; }
        public int courseID { get; set; }
    }
}
