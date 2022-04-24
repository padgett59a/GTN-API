using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public LanguageRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<Language> AllLanguages
        {
            get { return _gtnDbContext.Languages; }
        }
        public IEnumerable<Language> AllLanguagesShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<Language>("Languages", _gtnDbContext);
            }
        }

        public Language GetLanguageById(int langId)
        {
            return _gtnDbContext.Languages.Find(langId);
        }
        public int InsertLanguage(List<Language> languageList)
        {
            int addCount = 0;
            foreach (Language newItem in languageList)
            {
                var retVal = _gtnDbContext.Languages.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteLanguage(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Language delItem = this.GetLanguageById(delItemId);
                var retVal = _gtnDbContext.Languages.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateLanguage(Language language)
        {
            EntityEntry<Language> retVal = _gtnDbContext.Languages.Update(language);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }






    }
}
