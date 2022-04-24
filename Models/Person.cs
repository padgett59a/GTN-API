using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GTN_API.Models
{
    public class PersonOname
    {
        [Key]
        public int personID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public string Location { get; set; }
        public int? locID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public int? orgID { get; set; }
        public string Organization { get; set; }
        public int? personTypeID { get; set; }
        public string Role { get; set; }
    }

    public partial class Person
    {
        public Person()
        {
            CourseCores = new HashSet<CourseCore>();
            ExamTranslationLogs = new HashSet<ExamTranslationLog>();
            MasteringLogs = new HashSet<MasteringLog>();
            PersonPayRates = new HashSet<PersonPayRate>();
            SessionDists = new HashSet<SessionDist>();
            TranslationLogs = new HashSet<TranslationLog>();
        }

        public int personID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public int? orgID { get; set; }
        public int? personTypeID { get; set; }
        public int? locID { get; set; }

        public virtual Location Loc { get; set; }
        public virtual Organization Org { get; set; }
        public virtual PersonType PersonType { get; set; }
        public virtual ICollection<CourseCore> CourseCores { get; set; }
        public virtual ICollection<ExamTranslationLog> ExamTranslationLogs { get; set; }
        public virtual ICollection<MasteringLog> MasteringLogs { get; set; }
        public virtual ICollection<PersonPayRate> PersonPayRates { get; set; }
        public virtual ICollection<SessionDist> SessionDists { get; set; }
        public virtual ICollection<TranslationLog> TranslationLogs { get; set; }
    }
}
