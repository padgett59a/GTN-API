using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GTN_API.Models
{
    public class SessionCoreRepository : ISessionCoreRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public SessionCoreRepository(
            GtnDbContext gtnDbContext
            )
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<SessionCore> AllSessionCores
        {
            get
            {
                return _gtnDbContext.SessionCores;
            }
        }
        public IEnumerable<SessionCore> AllSessionCoresShortNotes
        {
            get 
            {
                return GTNCommonRepository.TableShortNotes<SessionCore>("SessionCores", _gtnDbContext);
            }
        }

        public SessionCore GetSessionCoreById(int SessionCode)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.SessionCores.Find(SessionCode);
        }
        public EntityEntry<SessionCore> InsertSessionCore(SessionCore SessionCore)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.SessionCores.Add(SessionCore);
        }

        //This takes a SessionCore list and coverts it to a SessionCoreCName list 
        public List<SessionCoreCName> ConvertSessionsToCNames(List<SessionCore> SessionCores)
        {
            //Converts courseID to courseName for easy display
            List<SessionCoreCName> SessionCnameList = new List<SessionCoreCName>();
            CourseCoreRepository courseRepo = new CourseCoreRepository(_gtnDbContext);
            PersonsRepository personsRepo = new PersonsRepository(_gtnDbContext);

            IEnumerable<CourseCore> courseList = courseRepo.AllCourseCores.ToList();
            IEnumerable<Person> personsList = personsRepo.AllPersons.ToList();

            foreach (SessionCore Session in SessionCores) {
                SessionCoreCName newSessionCname = new SessionCoreCName();
                newSessionCname.sessionCoreID = Session.sessionCoreID;
                //CourseName 
                newSessionCname.CourseName = courseList.First(c => c.courseCoreID == Session.courseCoreID).CourseName;
                newSessionCname.SessionName = Session.SessionName;
                newSessionCname.SessionCode = Session.SessionCode;
                newSessionCname.Notes = Session.Notes;
                SessionCnameList.Add(newSessionCname);
            }
            return SessionCnameList;
        }

        //This takes a SessionCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertSessions(List<SessionCore> SessionCores)
        {
            int addCount = 0;
            foreach (SessionCore newSession in SessionCores)
            {
                var retVal = _gtnDbContext.SessionCores.Add(newSession);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteSessions(List<int> delItemList)
        {
            int delCount = 0;
            //SessionCore delItem;
            foreach (int delItemId in delItemList)
            {
                SessionCore delSession = this.GetSessionCoreById(delItemId);
                var retVal = _gtnDbContext.SessionCores.Remove(delSession);
                if (retVal.State == EntityState.Deleted) {delCount++;}
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }

        public EntityState UpdateSessionCore(SessionCore Session)
        {
            EntityEntry<SessionCore> retVal = _gtnDbContext.SessionCores.Update(Session);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }


    }
}
