using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class SessionDist
    {
        public int sessionDistID { get; set; }
        public int sessionID { get; set; }
        public int medTypeID { get; set; }
        public int locID { get; set; }
        public string ArchiveFormat { get; set; }
        public int? personID { get; set; }
        public DateTime? DistDate { get; set; }
        public bool? Masters { get; set; }
        public string Notes { get; set; }

        public virtual Location Loc { get; set; }
        public virtual MediaType MedType { get; set; }
        public virtual Person Person { get; set; }
        public virtual Session Session { get; set; }
    }
}
