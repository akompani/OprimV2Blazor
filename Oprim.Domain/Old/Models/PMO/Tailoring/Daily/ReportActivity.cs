using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    [Index(nameof(ReportId),nameof(ArticleId), nameof(ScheduleActivityId), IsUnique = true)]
    public class ReportActivity : ICacheModel
    {
        public ReportActivity()
        {

        }

        public ReportActivity(long reportId, long articleId, ScheduleActivity scheduleActivity, ReportActivityTypes reportActivityType, decimal prevProgress)
        {
            ReportId = reportId;
            ArticleId = articleId;
            ScheduleActivity = scheduleActivity;
            ScheduleActivityId = scheduleActivity.Id;
            ReportActivityType = reportActivityType;
            PrevProgress = prevProgress;
            DailyProgress = 0;
            CumProgress = prevProgress;

            ReCalculateProgress();
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ReportId")] public Report Report { get; set; }
        public long ReportId { get; set; }

        [ForeignKey("ArticleId")] public WorkArticle Article { get; set; }
        public long ArticleId { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        public int Row { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(5,2)")] public decimal PrevProgress { get; set; }

        public ReportActivityTypes ReportActivityType { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(5,2)")] public decimal DailyProgress { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(5,2)")] public decimal CumProgress { get; set; }

        [MaxLength(50)]
        public string? Notes { get; set; }

        public bool Finalized { get; set; }

        public void SetDailyProgress(decimal progress)
        {
            DailyProgress = progress;
            ReCalculateProgress();
        }

        public void ReCalculateProgress()
        {
            CumProgress = DailyProgress + PrevProgress;

            if (this.CumProgress > 100)
            {
                DailyProgress = 100 - PrevProgress;
                this.CumProgress = 100;
            }
        }

        public void Reset()
        {
            CumProgress = PrevProgress;
            DailyProgress = 0;
        }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ReportActivity), ReportId),
                ICacheModel.CreateCacheName(nameof(ProjectItem), "SummaryReport", ReportId)
            };
        }

        public ReportActivity Clone(long newReportId,long newArticleId)
        {
            var ra= new ReportActivity()
            {
                ReportId = newReportId,
                ArticleId = newArticleId,
                ScheduleActivityId = this.ScheduleActivityId,
                ReportActivityType = this.ReportActivityType,
                PrevProgress = this.PrevProgress
            };

            ra.SetDailyProgress(this.DailyProgress);

            return ra;
        }
    }
}
