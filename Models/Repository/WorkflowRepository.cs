using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Data.SqlClient;

namespace GTN_API.Models
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public WorkflowRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        //Gets all Course/Languages and shows which are in translation
        public List<TrxStatus> GetTrxStatuses(Int16 @inTrxOnly, GtnDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@inTrxOnly",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = inTrxOnly
                        }
                };

            dbContext.Database.SetCommandTimeout(180);
            var retVal = dbContext.Set<TrxStatus>().FromSqlRaw("[dbo].[SP_GetTrxCourses] @inTrxOnly", param);
            return retVal.ToList();
        }

        public List<TrxStatus> GetMrxStatuses(GtnDbContext dbContext)
        {
            //var param = new SqlParameter[] {
            //            new SqlParameter() {
            //                ParameterName = "@inTrxOnly",
            //                SqlDbType =  System.Data.SqlDbType.Bit,
            //                Direction = System.Data.ParameterDirection.Input,
            //                Value = inTrxOnly
            //            }
            //    };

            dbContext.Database.SetCommandTimeout(180);
            //var retVal = dbContext.Set<MrxStatus>().FromSqlRaw("[dbo].[SP_GetMrxCourses] @inTrxOnly", param);
            //NOTE Type MrxStatus == Type TrxStatus so just re-using TrxStatus here
            var retVal = dbContext.Set<TrxStatus>().FromSqlRaw("[dbo].[SP_GetMrxCourses]");
            return retVal.ToList();
        }


        //takes a TxSemester obj, returns translation-ready TrxLog (with Courses), ExamsTrxLog (might be empty), MasteringLog (with Courses)
        public List<MxLog> GetMasteringLogs(TxSemester trxSem, GtnDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@langID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.LangID
                        },
                        new SqlParameter() {
                            ParameterName = "@semCode",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.SemesterCode
                        },
                        new SqlParameter() {
                            ParameterName = "@corsCodes",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.CourseCodes
                        }
                };

            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            var retVal = dbContext.Set<MxLog>().FromSqlRaw("[dbo].[SP_Mrx_Sem] @langID, @semCode, @corsCodes", param);
            return retVal.ToList();
        }

       public List<DistrSession> GetDistributionSessions(string sessionCoreIDs, GtnDbContext dbContext)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@corsCodes",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = sessionCoreIDs
            };

            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            //var retVal = dbContext.Set<DistrSession>().FromSqlRaw("[dbo].[SP_Get_Course_Sessions] @corsCodes, @langID ", param);
            var retVal = dbContext.Set<DistrSession>().FromSqlRaw("[dbo].[SP_Get_Course_Sessions] @corsCodes", param);
            return retVal.ToList();
        }

        //takes a TxSemester obj, returns translation-ready TrxLog (with Courses), ExamsTrxLog (might be empty), MasteringLog (with Courses)
        public List<TxLog> TranslateLanguage(TxSemester trxSem, GtnDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@langID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.LangID
                        },
                        new SqlParameter() {
                            ParameterName = "@semCode",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.SemesterCode
                        },
                        new SqlParameter() {
                            ParameterName = "@corsCodes",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.CourseCodes
                        },
                        new SqlParameter() {
                            ParameterName = "@genExams",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.GenExams
                        }
                };
            
            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            var retVal = dbContext.Set<TxLog>().FromSqlRaw("[dbo].[SP_Trx_Sem] @langID, @semCode, @corsCodes, @genExams", param);
            return retVal.ToList();
        }

        public EntityState UpdateTranslationLog(TranslationLog tLog)
        {
            EntityEntry<TranslationLog> retVal = _gtnDbContext.TranslationLog.Update(tLog);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }
        public EntityState UpdateMasteringLog(MasteringLog mLog)
        {
            EntityEntry<MasteringLog> retVal = _gtnDbContext.MasteringLog.Update(mLog);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }

        public TranslationLog GetTranslationLogById(int tLogID)
        {
            return _gtnDbContext.TranslationLog.Find(tLogID);
        }
        public MasteringLog GetMasteringLogById(int mLogID)
        {
            return _gtnDbContext.MasteringLog.Find(mLogID);
        }
    }
}
