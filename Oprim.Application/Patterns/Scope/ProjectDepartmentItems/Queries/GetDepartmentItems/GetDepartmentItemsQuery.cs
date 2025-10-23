using MediatR;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Queries.GetDepartmentItems;

public class GetDepartmentItemsQuery:IRequest<List<ProjectDepartmentItem>>
{
    public int ProjectId { get; set; }
    public int ProjectDepartmentId { get; set; } = 0;
}