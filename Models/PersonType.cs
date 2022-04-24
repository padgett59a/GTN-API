using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class PersonType
    {
        public PersonType()
        {
            People = new HashSet<Person>();
        }

        public int personTypeID { get; set; }
        public string PersonTypeName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
