using MediatR;
using Oprim.Application.Dtos.Scope;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;

public class CreateDepartmentCommand : IRequest
{
    public CreateDepartmentDTO CreateDepartmentDTO { get; set; }
}