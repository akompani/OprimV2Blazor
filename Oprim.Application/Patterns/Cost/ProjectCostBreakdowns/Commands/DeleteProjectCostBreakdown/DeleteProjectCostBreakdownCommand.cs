using MediatR;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Commands.DeleteProjectCostBreakdown;

public class DeleteProjectCostBreakdownCommand : IRequest
{
    public int Id { get; set; }
}