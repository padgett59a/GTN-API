using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class LangCoursesTemp
    {
        public int lcID { get; set; }
        public string LangName { get; set; }
        public int langID { get; set; }
        public string SemesterName { get; set; }
        public string SemesterCode { get; set; }
        public string CourseName { get; set; }
        public int courseCoreID { get; set; }
        public bool InTranslation { get; set; }
        public bool? TrxComplete { get; set; }
        public bool? MrxComplete { get; set; }
    }
}
