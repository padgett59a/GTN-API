using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public PersonsRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }


        public IEnumerable<Person> AllPersons
        {
            get { return _gtnDbContext.Persons.ToList(); }
        }
        public IEnumerable<Person> AllPersonsShortNotes
        {
            get { return GTNCommonRepository.TableShortNotes<Person>("Persons", _gtnDbContext); }
        }

        public Person GetPersonById(int personID)
        {
            return _gtnDbContext.Persons.Find(personID);
        }

        //This takes a Person list and coverts it to a PersonOname list 
        public List<PersonOname> ConvertPersonsToOnames(List<Person> Persons)
        {
            //Converts Persons to PersonOnames for easy display
            OrganizationRepository orgRepo = new OrganizationRepository(_gtnDbContext);
            PersonTypeRepository personTypeRepo = new PersonTypeRepository(_gtnDbContext);
            List<PersonOname> PersonOnameList = new List<PersonOname>();
            LocationRepository locRepo = new LocationRepository(_gtnDbContext);
            IEnumerable<Organization> orgList = orgRepo.AllOrganizations.ToList();
            IEnumerable<Location> locList = locRepo.AllLocations.ToList();
            IEnumerable<PersonType> personTypeList = personTypeRepo.AllPersonTypes.ToList();

            foreach (Person Person in Persons)
            {
                PersonOname newPersonOname = new PersonOname();

                newPersonOname.personID = Person.personID;
                newPersonOname.FullName = Person.FullName;
                newPersonOname.Phone = Person.Phone;
                newPersonOname.Email = Person.Email;
                newPersonOname.locID = Person.locID;
                if (Person.locID != null)
                {
                    Location pLoc = locList.First(l => l.locID == Person.locID);
                    //newPersonOname.Location = $"{pLoc.City}, {pLoc.State}, {pLoc.Country}";
                    newPersonOname.City = pLoc.City;
                    newPersonOname.State = pLoc.State;
                    newPersonOname.Country = pLoc.Country;
                }
                newPersonOname.orgID = Person.orgID;
                if (Person.orgID != null)
                {
                    newPersonOname.Organization = orgList.First(o => o.orgID == Person.orgID).OrgName;
                }
                newPersonOname.personTypeID= Person.personTypeID;
                newPersonOname.Role = personTypeList.First(pt => pt.personTypeID == Person.personTypeID).PersonTypeName;
                newPersonOname.Notes = Person.Notes;

                PersonOnameList.Add(newPersonOname);
            }
            return PersonOnameList;
        }
        public Person ConvertOnameToPerson(PersonOname pOname)
        {
            Person retVal = new Person();
            retVal.personID = pOname.personID;
            retVal.FullName = pOname.FullName;
            retVal.Phone = pOname.Phone;
            retVal.Email = pOname.Email;
            LocationRepository locRepo = new LocationRepository(_gtnDbContext);

            //Save any new location, and lookup the locID
            List<Location> locations = locRepo.AllLocations.ToList();
            Location locExists = locations.Find(l => l.City == pOname.City && l.State == pOname.State && l.Country == pOname.Country);

            if (locExists == null)
            {
                Location newLoc = new Location();
                newLoc.City = pOname.City;
                newLoc.State = pOname.State;
                newLoc.Country = pOname.Country;
                List<Location> insLocs = new List<Location>();
                insLocs.Add(newLoc);
                locRepo.InsertLocations(insLocs);
                locations = locRepo.AllLocations.ToList();
                locExists = locations.Find(l => l.City == pOname.City && l.State == pOname.State && l.Country == pOname.Country);
                if (locExists == null) { throw new System.Collections.Generic.KeyNotFoundException($"ConvertOnameToPerson: No location record found for city: {pOname.City}, state: {pOname.State} and country: {pOname.Country}"); }
            }
            retVal.locID = locExists.locID;
            retVal.orgID = pOname.orgID;
            retVal.personTypeID = pOname.personTypeID;
            retVal.Notes = pOname.Notes;
            return retVal;
        }


        public int InsertPersons(List<PersonOname> PersonList)
        {
            int addCount = 0;
            foreach (PersonOname newItem in PersonList)
            {
                var retVal = _gtnDbContext.Persons.Add(ConvertOnameToPerson(newItem));
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeletePersons(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Person delItem = this.GetPersonById(delItemId);
                var retVal = _gtnDbContext.Persons.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdatePerson(Person Person)
        {
            EntityEntry<Person> retVal = _gtnDbContext.Persons.Update(Person);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

    }
}
