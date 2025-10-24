using MediatR;
using Oprim.Application.Dtos.Scope;
using Oprim.Application.Dtos.Scope.Departments;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;

public class CreateDepartmentCommand : IRequest
{
    public CreateDepartmentDTO CreateDepartmentDTO { get; set; }
}