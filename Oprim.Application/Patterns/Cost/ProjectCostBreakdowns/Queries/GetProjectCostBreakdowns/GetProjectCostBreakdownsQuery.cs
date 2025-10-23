using MediatR;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdowns;

public class GetProjectCostBreakdownsQuery:IRequest<List<ProjectCostBreakdown>>
{
    public int ProjectId { get; set; }
}