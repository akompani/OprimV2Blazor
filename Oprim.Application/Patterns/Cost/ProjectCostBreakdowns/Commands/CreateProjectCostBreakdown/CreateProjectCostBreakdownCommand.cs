using MediatR;
using Oprim.Application.Dtos.Cost;
using Oprim.Application.Dtos.Cost.CostBreakdowns;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Commands.CreateProjectCostBreakdown;

public class CreateProjectCostBreakdownCommand : IRequest
{
    public CreateCostBreakdownDTO CreateCostBreakdownDto { get; set; }
}