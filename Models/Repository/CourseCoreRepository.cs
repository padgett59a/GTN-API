using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using GTN_API.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class CourseCoreRepository : ICourseCoreRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public CourseCoreRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<CourseCore> AllCourseCores
        {
            //get { return _gtnDbContext.CourseCores; }
            get
            {
                return _gtnDbContext.CourseCores;
            }
        }
        public IEnumerable<CourseCore> AllCourseCoreShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<CourseCore>("CourseCores", _gtnDbContext);
            }
        }

        public CourseCore GetCourseCoreById(int CourseCode)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.CourseCores.Find(CourseCode);
        }
        public EntityEntry<CourseCore> InsertCourseCore(CourseCore CourseCore)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.CourseCores.Add(CourseCore);
        }

        //This takes a CourseCore list and coverts it to a CourseCoreSName list 
        public List<CourseCoreSName> ConvertCoursesToSNames(List<CourseCore> CourseCores)
        {
            //Converts Semester Code to SemesterName and Instructor.personID to Instructor Name for easy display
            List<CourseCoreSName> CourseCnameList = new List<CourseCoreSName>();
            CurriculumRepository currRepo = new CurriculumRepository(_gtnDbContext);
            SemesterCoreRepository semesterRepo = new SemesterCoreRepository(_gtnDbContext);
            PersonsRepository personsRepo = new PersonsRepository(_gtnDbContext);

            IEnumerable<SemesterCore> semesterList = semesterRepo.AllSemesterCores.ToList();
            IEnumerable<Person> personsList = personsRepo.AllPersons.ToList();

            foreach (CourseCore Course in CourseCores) {
                CourseCoreSName newSemCname = new CourseCoreSName();
                newSemCname.courseCoreID = Course.courseCoreID;
                newSemCname.CourseName = Course.CourseName;
                //SemesterName 
                newSemCname.SemesterName = semesterList.First(s => s.SemesterCode == Course.SemesterCode).SemesterName;
                newSemCname.CourseLetterCode = Course.CourseLetterCode;
                newSemCname.CourseNumberCode = Course.CourseNumberCode;
                newSemCname.HasWorkbook = Course.HasWorkbook;
                newSemCname.HasVideoText = Course.HasVideoText;
                //Instructor Name
                if (Course.instructorID != null)
                {
                    newSemCname.InstructorName = personsList.First(p => p.personID == Course.instructorID).FullName;
                }
                newSemCname.VideosInHand = Course.VideosInHand;
                newSemCname.MasteringFilesInHand = Course.MasteringFilesInHand;
                newSemCname.TextFilesInHand = Course.TextFilesInHand;
                newSemCname.Notes = Course.Notes;

                CourseCnameList.Add(newSemCname);
            }
            return CourseCnameList;
        }

        //This takes a CourseCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertCourses(List<CourseCore> CourseCores)
        {
            int addCount = 0;
            foreach (CourseCore newCourse in CourseCores)
            {
                var retVal = _gtnDbContext.CourseCores.Add(newCourse);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteCourses(List<int> delItemList)
        {
            int delCount = 0;
            //CourseCore delItem;
            foreach (int delItemId in delItemList)
            {
                CourseCore delCourse = this.GetCourseCoreById(delItemId);
                var retVal = _gtnDbContext.CourseCores.Remove(delCourse);
                if (retVal.State == EntityState.Deleted) {delCount++;}
            }
            _gtnDbContext.SaveChanges();
            return delCount;
        }

        public EntityState UpdateCourseCore(CourseCore Course)
        {
            EntityEntry<CourseCore> retVal = _gtnDbContext.CourseCores.Update(Course);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }


    }
}
