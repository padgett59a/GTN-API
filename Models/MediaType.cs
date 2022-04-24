using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class MediaType
    {
        public MediaType()
        {
            SessionDists = new HashSet<SessionDist>();
        }

        public int mediaTypeID { get; set; }
        public string MediaTypeName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<SessionDist> SessionDists { get; set; }
    }
}
