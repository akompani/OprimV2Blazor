using MediatR;
using Oprim.Domain.Entities.Quality;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Queries.GetDepartments;

public class GetDepartmentsQuery:IRequest<List<ProjectDepartment>>
{
    public int ProjectId { get; set; }
}