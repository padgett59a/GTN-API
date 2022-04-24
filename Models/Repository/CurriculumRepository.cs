using System;
using System.Collections.Generic;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public CurriculumRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<Curriculum> AllCurriculum

        {
            get
            {
                return _gtnDbContext.Curriculums;
            }
        }
        public IEnumerable<Curriculum> AllCurriculumShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<Curriculum>("Curriculums", _gtnDbContext);
            }
        }

        public Curriculum GetCurriculumById(Int32 curriculumID)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.Curriculums.Find(curriculumID);
        }

        public int InsertCurriculum(List<Curriculum> curriculum)
        {
            int addCount = 0;
            foreach (Curriculum newItem in curriculum)
            {
                var retVal = _gtnDbContext.Curriculums.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteCurriculum(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Curriculum delItem = this.GetCurriculumById(delItemId);
                var retVal = _gtnDbContext.Curriculums.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateCurriculum(Curriculum Curriculum)
        {
            EntityEntry<Curriculum> retVal = _gtnDbContext.Curriculums.Update(Curriculum);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

    }
}
