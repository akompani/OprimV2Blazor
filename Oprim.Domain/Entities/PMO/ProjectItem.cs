using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Domain.Entities.PMO;

public class ProjectItem : BaseProjectEntity
{
    

    [ForeignKey("ProjectItemGroupId")] public ProjectItemGroup ProjectItemGroup { get; set; }
    public int ProjectItemGroupId { get; set; }

    [ForeignKey("ProjectCostBreakdownId")] public ProjectCostBreakdown ProjectCostBreakdown { get; set; }
    public int ProjectCostBreakdownId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public int EngineeringLead { get; set; }

    public int ProcurementLead { get; set; }

    public string? Unit { get; set; }

    public double QuantityForOneHour { get; set; }

    public double EstimateQuantity { get; set; }

    public double TotalQuantity { get; set; }

    public double EstimateUnitCost { get; set; }

    public double EstimateCost { get; set; }

    public double TotalCost { get; set; }
}