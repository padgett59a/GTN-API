using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Location
    {
        public Location()
        {
            People = new HashSet<Person>();
            SessionDists = new HashSet<SessionDist>();
        }

        public int locID { get; set; }
        public string LocName { get; set; }
        public bool ArchiveLocation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<SessionDist> SessionDists { get; set; }
    }
}
