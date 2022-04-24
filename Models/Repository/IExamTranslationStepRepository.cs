using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTN_API.Models
{
    public interface IExamTranslationStepRepository
    {
        IEnumerable<ExamTranslationStep> AllExamTranslationSteps { get; }
        IEnumerable<ExamTranslationStep> AllExamTranslationStepsShortNotes { get; }
        ExamTranslationStep GetExamTranslationStepById(int tsId);
        int InsertExamTranslationStep(List<ExamTranslationStep> examTranslationStepList);
        int DeleteExamTranslationStep(List<int> delItemList);
        EntityState UpdateExamTranslationStep(ExamTranslationStep ExamTranslationStep);
    }
}
