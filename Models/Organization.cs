using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Organization
    {
        public Organization()
        {
            People = new HashSet<Person>();
        }

        public int orgID { get; set; }
        public string OrgName { get; set; }
        public string OrgLocation { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
