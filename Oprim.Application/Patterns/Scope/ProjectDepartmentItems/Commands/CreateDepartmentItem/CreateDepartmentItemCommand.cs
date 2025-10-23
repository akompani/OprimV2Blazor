using MediatR;
using Oprim.Application.Dtos.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Commands.CreateDepartmentItem;

public class CreateDepartmentItemCommand : IRequest
{
    public CreateDepartmentItemDTO CreateDepartmentItemDTO { get; set; }
}