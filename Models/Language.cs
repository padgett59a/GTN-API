using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Language
    {
        public Language()
        {
            Courses = new HashSet<Course>();
            MasteringCustomPays = new HashSet<MasteringCustomPay>();
            Semesters = new HashSet<Semester>();
            Sessions = new HashSet<Session>();
            TranslationCustomPays = new HashSet<TranslationCustomPay>();
        }

        public int langID { get; set; }
        public string LangName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<MasteringCustomPay> MasteringCustomPays { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<TranslationCustomPay> TranslationCustomPays { get; set; }
    }
}
