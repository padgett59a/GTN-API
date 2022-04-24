using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;

namespace GTN_API.Models
{
    public class UsersRepository : IUsersRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public UsersRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public List<Person> AllPersons
        {
            get { return _gtnDbContext.Persons.ToList(); }
        }

        public Person GetPersonById(int personID)
        {
            return _gtnDbContext.Persons.Find(personID);
        }
    }
}
