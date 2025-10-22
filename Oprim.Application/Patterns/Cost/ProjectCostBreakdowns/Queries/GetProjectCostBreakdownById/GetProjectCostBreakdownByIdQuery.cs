using MediatR;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdownById;

public class GetProjectCostBreakdownByIdQuery : IRequest<ProjectCostBreakdown>
{
    public int Id { get; set; }
}