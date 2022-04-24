using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class MasteringStepRepository : IMasteringStepRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public MasteringStepRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }
        public IEnumerable<MasteringStep> AllMasteringSteps 
        {
            get { return _gtnDbContext.MasteringSteps; }
        }
        public IEnumerable<MasteringStep> AllMasteringStepsShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<MasteringStep>("MasteringSteps", _gtnDbContext);
            }
        }

        public MasteringStep GetMasteringStepById(int msId)
        {
            return _gtnDbContext.MasteringSteps.Find(msId);
        }
        public int InsertMasteringStep(List<MasteringStep> masteringStepList)
        {
            int addCount = 0;
            foreach (MasteringStep newItem in masteringStepList)
            {
                var retVal = _gtnDbContext.MasteringSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteMasteringStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                MasteringStep delItem = this.GetMasteringStepById(delItemId);
                var retVal = _gtnDbContext.MasteringSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateMasteringStep(MasteringStep MasteringStep)
        {
            EntityEntry<MasteringStep> retVal = _gtnDbContext.MasteringSteps.Update(MasteringStep);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

    }
}
