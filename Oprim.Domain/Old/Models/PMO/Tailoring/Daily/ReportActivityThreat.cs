using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Risks;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    public class ReportActivityThreat: ICacheModel
    {
    [Key]
        public long Id { get; set; }

        [ForeignKey("ReportActivityId")] public ReportActivity ReportActivity { get; set; }
        public long ReportActivityId { get; set; }

        [ForeignKey("ProjectThreatId")] public ProjectThreat ProjectThreat { get; set; }
        public long ProjectThreatId { get; set; }

        public decimal Contribution { get; set; }

        public string? Notes { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ReportActivityThreat), ReportActivityId)};
        }

        public ReportActivityThreat Clone(long newReportActivityId)
        {
            return new ReportActivityThreat()
            {
                ReportActivityId = newReportActivityId,
                ProjectThreatId = this.ProjectThreatId,
                Contribution = this.Contribution,
                Notes = this.Notes
            };
        }

}
}
