using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Enums.WorkFlow;

namespace Oprim.Domain.Entities.WorkFlow;

public class WorkTemplateArticle : BaseEntity
{
    [ForeignKey("WorkTemplateId")] public WorkTemplate WorkTemplate { get; set; }
    public long WorkTemplateId { get; set; }

    [ForeignKey("RoleId")] public OrganizationRole? Role { get; set; }
    public long? RoleId { get; set; }

    [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
    public long? StakeholderId { get; set; }

    public byte Order { get; set; }

    public int FixTime { get; set; }

    public int FitOnBaseTimeDurationIndex { get; set; }

    public decimal Weight { get; set; }

    public ArticleActionTypes ArticleAction { get; set; }

    public bool SendNotificationOnCreate { get; set; }

    public string Notes { get; set; }
}