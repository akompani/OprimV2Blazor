using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Domain.Entities.PMO;

public class ProjectItem : BaseEntity
{
    [ForeignKey("ProjectItemGroupId")] public ProjectItemGroup ProjectItemGroup { get; set; } = default!;
    public long ProjectItemGroupId { get; set; }

    [ForeignKey("ProjectCostBreakdownId")] public ProjectCostBreakdown ProjectCostBreakdown { get; set; }= default!;
    public long ProjectCostBreakdownId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public int EngineeringLeadDays { get; set; }

    public int ProcurementLeadDays { get; set; }

    public string? Unit { get; set; }

    public double QuantityForOneHour { get; set; }

    public double EstimateQuantity { get; set; }

    public double TotalQuantity { get; set; }

    public double EstimateUnitCost { get; set; }

    public double EstimateCost { get; set; }

    public double TotalCost { get; set; }
}