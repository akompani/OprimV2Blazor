using MediatR;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Queries.GetDepartmentById;

public class GetDepartmentByIdQuery:IRequest<ProjectDepartment>
{
    public int Id { get; set; }
}