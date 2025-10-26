using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Enums.Common;
using Oprim.Domain.Enums.WorkFlow;

namespace Oprim.Domain.Entities.WorkFlow;

public class WorkArticle : BaseProjectEntity
{
    public long PrevArticleId { get; set; }

    public int Row { get; set; }

    [ForeignKey("WorkId")] public Work Work { get; set; }
    public long WorkId { get; set; }

    [ForeignKey("WorkTemplateArticleId")] public WorkTemplateArticle WorkTemplateArticle { get; set; }
    public long WorkTemplateArticleId { get; set; }

    [ForeignKey("StakeholderId")] public Stakeholder Stakeholder { get; set; }
    public long StakeholderId { get; set; }
    
    public DateTime PlanStart { get; set; }
    
    public DateTime PlanFinish { get; set; }

    public int PlanDurationHours { get; set; }

    #region UpdateFields

    public DateTime? ActualFinish { get; set; }

    public int ActualDurationHours { get; set; }

    public int DelayHours { get; set; }

    public int Score { get; set; }

    public int Penalty { get; set; }
    
    public DateTime? PenaltyOrScoreApplyTime { get; set; }

    public string? Notes { get; set; }

    public SevenPointLikertScales QualityValue { get; set; }

    public WorkSituations Situation { get; set; }

    public bool IsFinalArticle { get; set; }

    #endregion
}