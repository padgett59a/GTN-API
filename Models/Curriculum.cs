using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Curriculum
    {
        public Curriculum()
        {
            SemesterCores = new HashSet<SemesterCore>();
        }

        public int curriculumID { get; set; }
        public string CurriculumName { get; set; }

        public virtual ICollection<SemesterCore> SemesterCores { get; set; }
    }
}
