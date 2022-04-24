using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public MediaTypeRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<MediaType> AllMediaTypes
        {
            get { return _gtnDbContext.MediaTypes; }
        }

        public IEnumerable<MediaType> AllMediaTypesShortNotes
        {
            get { return GTNCommonRepository.TableShortNotes<MediaType>("MediaTypes", _gtnDbContext); }
        }

        public MediaType GetMediaTypeById(int id)
        {
            return _gtnDbContext.MediaTypes.Find(id);
        }

        public int InsertMediaType(List<MediaType> mediaTypeList)
        {
            int addCount = 0;
            foreach (MediaType newItem in mediaTypeList)
            {
                var retVal = _gtnDbContext.MediaTypes.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteMediaType(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                MediaType delItem = this.GetMediaTypeById(delItemId);
                var retVal = _gtnDbContext.MediaTypes.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateMediaType(MediaType MediaType)
        {
            EntityEntry<MediaType> retVal = _gtnDbContext.MediaTypes.Update(MediaType);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

    }
}
