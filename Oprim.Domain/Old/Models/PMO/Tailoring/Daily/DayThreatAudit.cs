using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.PMO.Risks;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    [Index(nameof(ProjectId), nameof(Date), nameof(ScheduleActivityId), nameof(ThreatId), IsUnique = true)]
    public class DayThreatAudit : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public string Date { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("ThreatId")] public ProjectThreat Threat { get; set; }
        public long ThreatId { get; set; }


        public int OwnerStakeholderId { get; set; }
        public bool AcceptByOwner { get; set; }
        public string OwnerNotes { get; set; }

        public int AuditThreatId { get; set; }
        public int AuditStakeholderId { get; set; }
        public string AuditNotes { get; set; }
        public bool AcceptOwnerRejectByAuditor { get; set; }

        public int RefereeThreatId { get; set; }
        public int RefereeStakeholderId { get; set; }
        public string RefereeNotes { get; set; }


        public double CalculatedImpactWeight { get; set; }
        public string[] DefaultCacheNames()
        {
            return new[] { $"{nameof(DayThreatAudit)}-{ProjectId}-{Date}" };
        }
    }
}
