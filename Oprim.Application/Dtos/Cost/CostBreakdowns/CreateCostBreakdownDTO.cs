using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.Cost.CostBreakdowns;

public class CreateCostBreakdownDTO: BaseProjectDTO
{
    public string Code { get; set; }
    public string Name { get; set; }
}