using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Entities.Schedule;
using Oprim.Domain.Enums.WorkFlow;

namespace Oprim.Domain.Entities.WorkFlow;

public class Work : BaseProjectEntity
{
    [ForeignKey("ProjectCalendarId")] public ProjectCalendar? ProjectCalendar { get; set; }
    public long ProjectCalendarId { get; set; }

    [ForeignKey("WorkTemplateId")] public WorkTemplate? WorkTemplate { get; set; }
    public long WorkTemplateId { get; set; }

    public int ScheduleWorkId { get; set; }

    public bool WorkFlowWithDocument { get; set; }

    public long DocumentTypeId { get; set; } = 0;

    public long DocumentId { get; set; }

    [MaxLength(30)] public string Code { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    public string? Notes { get; set; }

    public bool Critical { get; set; }

    public bool Important { get; set; }

    public DateTime PlanStart { get; set; }

    public DateTime PlanFinish { get; set; }

    public int PlanDurationHours { get; set; }

    #region UpdateFields

    public DateTime ActualStart { get; set; }

    public DateTime ActualFinish { get; set; }

    public int ActualDurationHours { get; set; } = 0;

    public WorkSituations Situation { get; set; }

    public decimal Progress { get; set; }

    public long LastArticleId { get; set; }
    #endregion
}