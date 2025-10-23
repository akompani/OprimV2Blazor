using MediatR;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Queries.GetDepartmentItemById;

public class GetDepartmentItemByIdQuery:IRequest<ProjectDepartmentItem>
{
    public int Id { get; set; }
}