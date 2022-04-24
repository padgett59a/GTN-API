using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public LocationRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<Location> AllLocations
        {
            get { return _gtnDbContext.Locations; }
        }

        public Location GetLocationById(int langId)
        {
            return _gtnDbContext.Locations.Find(langId);
        }
        public int InsertLocations(List<Location> locationList)
        {
            int addCount = 0;
            foreach (Location newItem in locationList)
            {
                var retVal = _gtnDbContext.Locations.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteLocation(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Location delItem = this.GetLocationById(delItemId);
                var retVal = _gtnDbContext.Locations.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateLocation(Location location)
        {
            EntityEntry<Location> retVal = _gtnDbContext.Locations.Update(location);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }






    }
}
