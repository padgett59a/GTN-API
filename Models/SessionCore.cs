using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public class SessionCoreCName //Session Object having CourseName (vice courseCoreID)
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Int32 sessionCoreID { get; set; }
        public string CourseName { get; set; }
        public string SessionName { get; set; }
        public decimal SessionCode { get; set; }
        public string Notes { get; set; }
    }

    public partial class SessionCore
    {
        public SessionCore()
        {
            Sessions = new HashSet<Session>();
        }

        public int sessionCoreID { get; set; }
        public int courseCoreID { get; set; }
        public string SessionName { get; set; }
        public decimal SessionCode { get; set; }
        public string Notes { get; set; }

        public virtual CourseCore CourseCore { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
