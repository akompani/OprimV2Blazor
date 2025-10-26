using System.ComponentModel.DataAnnotations;
using Oprim.Application.Dtos.Common;
using Oprim.Domain.Enums.WorkFlow;

namespace Oprim.Application.Dtos.WorkFlow.WorkTemplateArticles;

public class CreateWorkTemplateArticleDTO : BaseProjectDTO
{
    public long WorkTemplateId { get; set; }

    public long RoleId { get; set; }

    public long StakeholderId { get; set; }

    public byte Order { get; set; }

    public int FixTime { get; set; }

    public int FitOnBaseTimeDurationIndex { get; set; }

    public decimal Weight { get; set; }

    public ArticleActionTypes ArticleAction { get; set; }

    public bool SendNotificationOnCreate { get; set; }
    
}