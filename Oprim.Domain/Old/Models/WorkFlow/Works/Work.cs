using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.WorkFlow.Works
{
    [Index(nameof(Code),IsUnique = true)]
    public class Work : ICacheModel
    {
       

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectCalendarId")] public ProjectCalendar? ProjectCalendar { get; set; }
        public int ProjectCalendarId { get; set; }

        [ForeignKey("WorkBaseId")] public WorkBase? WorkBase { get; set; }
        public int WorkBaseId { get; set; }

        public int ScheduleWorkId { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder? Creator { get; set; }
        public int CreatorId { get; set; }

        [MaxLength(20)]
        public string? CreatorTime { get; set; }

        public bool WorkFlowWithDocument { get; set; }

        [DefaultValue(0)] public int DocumentTypeId { get; set; } = 0;

        public long DocumentId { get; set; }

        [MaxLength(30)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string? Notes { get; set; }

        public bool Critical { get; set; }
        public bool Important { get; set; }

        [ForeignKey("DoerId")] public Stakeholder? Doer { get; set; }
        public int DoerId { get; set; }

        public int DoDuration { get; set; }

        [ForeignKey("AuditorId")] public Stakeholder? Auditor { get; set; }
        public int AuditorId { get; set; }

        public int AuditDuration { get; set; }

        public decimal Progress { get; set; }

        public string? LastChangeTime { get; set; }

        public long LastArticleId { get; set; }

        public long FinalArticleId { get; set; }

        [MaxLength(20)]
        public string? PlanStart { get; set; }

        [MaxLength(20)]
        public string? PlanFinish { get; set; }

        public int PlanDuration { get; set; }
        
        [MaxLength(20)]
        public string? ActualStart { get; set; }

        [MaxLength(20)]
        public string? ActualFinish { get; set; }

        public int? ActualDuration { get; set; }

        public bool Completed { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []
            {
                ICacheModel.CreateCacheName(nameof(Work), ProjectId),
                ICacheModel.CreateCacheName(nameof(WorkArticle), Id)
            };
        }
    }
}
