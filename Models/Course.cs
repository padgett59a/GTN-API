using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Course
    {
        public int courseID { get; set; }
        public int courseCoreID { get; set; }
        public int langID { get; set; }
        public bool? TrxComplete { get; set; }
        public bool? MrxComplete { get; set; }

        public virtual CourseCore CourseCore { get; set; }
        public virtual Language Lang { get; set; }
    }
}
