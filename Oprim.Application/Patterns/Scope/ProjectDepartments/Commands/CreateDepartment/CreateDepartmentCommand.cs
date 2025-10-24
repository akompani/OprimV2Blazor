using MediatR;
using Oprim.Application.Dtos.Scope;
using Oprim.Application.Dtos.Scope.Departments;

namespace Oprim.Application.Patterns.Scope.ProjectDepartments.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest
{
    public CreateDepartmentDTO CreateDepartmentDTO { get; set; }
}