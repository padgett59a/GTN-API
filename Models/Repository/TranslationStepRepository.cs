using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class TranslationStepRepository : ITranslationStepRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public TranslationStepRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<TranslationStep> AllTranslationSteps
        {
            get { return _gtnDbContext.TranslationSteps; }
        }
        public IEnumerable<TranslationStep> AllTranslationStepsShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<TranslationStep>("TranslationSteps", _gtnDbContext);
            }
        }

        public TranslationStep GetTranslationStepById(int tsID)
        {
            return _gtnDbContext.TranslationSteps.Find(tsID);
        }
        public int InsertTranslationStep(List<TranslationStep> translationStepList)
        {
            int addCount = 0;
            foreach (TranslationStep newItem in translationStepList)
            {
                var retVal = _gtnDbContext.TranslationSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteTranslationStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                TranslationStep delItem = this.GetTranslationStepById(delItemId);
                var retVal = _gtnDbContext.TranslationSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateTranslationStep(TranslationStep TranslationStep)
        {
            EntityEntry<TranslationStep> retVal = _gtnDbContext.TranslationSteps.Update(TranslationStep);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }
    }
}
