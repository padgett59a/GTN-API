using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class ExamTranslationStepRepository : IExamTranslationStepRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public ExamTranslationStepRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<ExamTranslationStep> AllExamTranslationSteps
        {
            get { return _gtnDbContext.ExamTranslationSteps; }
        }
        public IEnumerable<ExamTranslationStep> AllExamTranslationStepsShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<ExamTranslationStep>("ExamTranslationSteps", _gtnDbContext);
            }
        }

        public ExamTranslationStep GetExamTranslationStepById(int tsID)
        {
            return _gtnDbContext.ExamTranslationSteps.Find(tsID);
        }
        public int InsertExamTranslationStep(List<ExamTranslationStep> examExamTranslationStepList)
        {
            int addCount = 0;
            foreach (ExamTranslationStep newItem in examExamTranslationStepList)
            {
                var retVal = _gtnDbContext.ExamTranslationSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteExamTranslationStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                ExamTranslationStep delItem = this.GetExamTranslationStepById(delItemId);
                var retVal = _gtnDbContext.ExamTranslationSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateExamTranslationStep(ExamTranslationStep ExamTranslationStep)
        {
            EntityEntry<ExamTranslationStep> retVal = _gtnDbContext.ExamTranslationSteps.Update(ExamTranslationStep);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }
    }
}
