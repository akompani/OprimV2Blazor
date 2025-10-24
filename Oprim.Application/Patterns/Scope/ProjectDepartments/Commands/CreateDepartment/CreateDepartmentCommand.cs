using MediatR;
using Oprim.Application.Dtos.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest
{
    public CreateDepartmentDTO CreateDepartmentDTO { get; set; }
}