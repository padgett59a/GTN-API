using GTN_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTN_API.Models
{
    public interface IWorkflowRepository
    {
        List<TxLog> TranslateLanguage(TxSemester trxSem, GtnDbContext dbContext);
        List<TrxStatus> GetTrxStatuses(Int16 @inTrxOnly, GtnDbContext dbContext);
        List<TrxStatus> GetMrxStatuses(GtnDbContext dbContext);
        List<MxLog> GetMasteringLogs(TxSemester trxSem, GtnDbContext dbContext);

        EntityState UpdateTranslationLog(TranslationLog tLog);
        EntityState UpdateMasteringLog(MasteringLog tLog);
        TranslationLog GetTranslationLogById(int tLogID);
        MasteringLog GetMasteringLogById(int mLogID);
        List<DistrSession> GetDistributionSessions(string sessionCoreIDs, GtnDbContext dbContext);

    }
}
