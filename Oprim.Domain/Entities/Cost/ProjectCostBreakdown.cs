using Oprim.Domain.Common;
namespace Oprim.Domain.Entities.Cost;

public class ProjectCostBreakdown : BaseProjectEntity
{
   
    public string Code { get; set; }
    public string Name { get; set; }

    public long TopLevelId { get; set; }

    public long EstimateCost { get; set; }

    public long TotalCost { get; set; }
}