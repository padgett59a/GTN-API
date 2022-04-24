﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GTN_API.Models
{
    public interface ISessionCoreRepository
    {
        IEnumerable<SessionCore> AllSessionCores { get; }
        IEnumerable<SessionCore> AllSessionCoresShortNotes { get;}
        SessionCore GetSessionCoreById(int SessionCode);
        EntityEntry<SessionCore> InsertSessionCore(SessionCore SessionCore);
        List<SessionCoreCName> ConvertSessionsToCNames(List<SessionCore> SessionCores);
        int InsertSessions(List<SessionCore> SessionCores);
        int DeleteSessions(List<int> SessionCodes);
        EntityState UpdateSessionCore(SessionCore SessionCore);
    }
}
