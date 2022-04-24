using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public class CourseCoreSName //Course Object having Semester Name (vice SemsterCode)
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Int32 courseCoreID { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public string CourseLetterCode { get; set; }
        public Int16? CourseNumberCode { get; set; }
        public Boolean HasWorkbook { get; set; }
        public Boolean HasVideoText { get; set; }
        public string InstructorName { get; set; }
        public Boolean VideosInHand { get; set; }
        public Boolean MasteringFilesInHand { get; set; }
        public Boolean TextFilesInHand { get; set; }
        public string Notes { get; set; }
    }

    public partial class CourseCore
    {
        public CourseCore()
        {
            Courses = new HashSet<Course>();
            SessionCores = new HashSet<SessionCore>();
        }

        public int courseCoreID { get; set; }
        public string SemesterCode { get; set; }
        public string CourseName { get; set; }
        public string CourseLetterCode { get; set; }
        public bool HasWorkbook { get; set; }
        public bool HasVideoText { get; set; }
        public int? instructorID { get; set; }
        public bool VideosInHand { get; set; }
        public bool MasteringFilesInHand { get; set; }
        public bool TextFilesInHand { get; set; }
        public short? CourseNumberCode { get; set; }
        public string Notes { get; set; }

        public virtual Person Instructor { get; set; }
        public virtual SemesterCore SemesterCodeNavigation { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SessionCore> SessionCores { get; set; }
    }
}
