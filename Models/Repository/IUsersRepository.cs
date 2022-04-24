﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTN_API.Models
{
    public interface IUsersRepository
    {
        List<Person> AllPersons { get; }
        Person GetPersonById(int personID);
    }
}
