using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.WorkFlow;

namespace Oprim.Domain.Old.Models.Communications.DecisionMinutes
{
    public class DecisionMinuteItem : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        public string? OldDecisionMinuteIds { get; set; }

        [ForeignKey("DecisionMinuteId")] public DecisionMinute? DecisionMinute { get; set; }
        public int DecisionMinuteId { get; set; }

        [ForeignKey("DepartmentItemId")] public ProjectDepartmentItem? DepartmentItem { get; set; }
        public long DepartmentItemId { get; set; }

        public byte Row { get; set; }

        [MaxLength(40)]
        public string Code { get; set; }

        public string Name { get; set; }

        [ForeignKey("GroupId")] public DecisionMinuteItemGroup? Group { get; set; }
        public int GroupId { get; set; }

        [ForeignKey("OwnerId")] public Stakeholder? Owner { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("SupervisorId")] public Stakeholder? Supervisor { get; set; }
        public int SupervisorId { get; set; }

        public long WorkId { get; set; }

        [MaxLength(20)]
        public string PlanFinish { get; set; }

        public string? Notes { get; set; }

        public MinuteItemSituations Situation { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(DecisionMinuteItem), DecisionMinuteId) };
        }
    }
}
