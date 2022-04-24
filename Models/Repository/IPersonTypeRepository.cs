using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTN_API.Models
{
    public interface IPersonTypeRepository
    {
        IEnumerable<PersonType> AllPersonTypes { get; }
        PersonType GetPersonTypeById(int langId);
        int InsertPersonType(List<PersonType> mediaTypeList);
        int DeletePersonType(List<int> delItemList);
        EntityState UpdatePersonType(PersonType PersonType);
    }
}
