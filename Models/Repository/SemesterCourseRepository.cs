using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public class SemesterCourseRepository : ISemesterCourseRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public SemesterCourseRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCourses
        {
            get { return _gtnDbContext.DistrSemesterCourse; }
        }
        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCoursesShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<DistrSemesterCourse>("DistrSemesterCourse", _gtnDbContext);
            }
        }
    }
}
