using MediatR;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.DeleteDepartment;

public class DeleteDepartmentCommand:IRequest
{
    public int Id { get; set; }
}