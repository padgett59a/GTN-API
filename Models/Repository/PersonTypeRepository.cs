using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class PersonTypeRepository : IPersonTypeRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public PersonTypeRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<PersonType> AllPersonTypes
        {
            get { return _gtnDbContext.PersonTypes; }
        }

        public PersonType GetPersonTypeById(int id)
        {
            return _gtnDbContext.PersonTypes.Find(id);
        }

        public int InsertPersonType(List<PersonType> personTypeList)
        {
            int addCount = 0;
            foreach (PersonType newItem in personTypeList)
            {
                var retVal = _gtnDbContext.PersonTypes.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeletePersonType(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                PersonType delItem = this.GetPersonTypeById(delItemId);
                var retVal = _gtnDbContext.PersonTypes.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdatePersonType(PersonType PersonType)
        {
            EntityEntry<PersonType> retVal = _gtnDbContext.PersonTypes.Update(PersonType);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

    }
}
