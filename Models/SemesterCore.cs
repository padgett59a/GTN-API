using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public class SemesterCoreCName
    {
        public string SemesterName { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public string SemesterCode { get; set; }
        public string CurriculumName { get; set; }
        public Int16? NumberOfVideoSessions { get; set; }
        public string Notes { get; set; }

    }

    public partial class SemesterCore
    {
        public SemesterCore()
        {
            CourseCores = new HashSet<CourseCore>();
            Semesters = new HashSet<Semester>();
        }


        public string SemesterCode { get; set; }
        public string SemesterName { get; set; }
        public int? curriculumID { get; set; }
        public short? NumberOfVideoSessions { get; set; }
        public string Notes { get; set; }

        public virtual Curriculum Curriculum { get; set; }
        public virtual ICollection<CourseCore> CourseCores { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
