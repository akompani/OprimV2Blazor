using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Domain.Entities.Cost;

public class ProjectCostBreakdown : BaseEntity
{
    [ForeignKey("ProjectId")] public Project Project { get; set; } = default!;
    public long ProjectId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public long TopLevelId { get; set; }

    public long EstimateCost { get; set; }

    public long TotalCost { get; set; }
}