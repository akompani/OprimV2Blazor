using MediatR;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Commands.CreateProjectCostBreakdown;

public class CreateProjectCostBreakdownCommand : IRequest
{
    public string Name { get; set; }
}