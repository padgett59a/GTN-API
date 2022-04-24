﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public interface ISemesterCoreRepository
    {
        IEnumerable<SemesterCore> AllSemesterCores { get; }
        IEnumerable<SemesterCore> AllSemesterCoresShortNotes { get; }
        SemesterCore GetSemesterCoreById(string semesterCode);
        EntityEntry<SemesterCore> InsertSemesterCore(SemesterCore SemesterCore);
        List<SemesterCoreCName> ConvertToCNames(List<SemesterCore> SemesterCores);
        int InsertSemesters(List<SemesterCore> SemesterCores);
        int DeleteSemesters(List<string> semesterCodes);
        EntityState UpdateSemesterCore(SemesterCore semesterCore);
    }
}
