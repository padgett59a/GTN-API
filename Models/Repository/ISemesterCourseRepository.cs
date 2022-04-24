using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public interface ISemesterCourseRepository 
    {

        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCourses { get; }
        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCoursesShortNotes { get; }

    }
}
