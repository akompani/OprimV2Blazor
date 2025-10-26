using MediatR;
using Oprim.Application.Dtos.Scope;
using Oprim.Application.Dtos.Scope.DepartmentItems;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Commands.CreateDepartmentItem;

public class CreateDepartmentItemCommand : IRequest
{
    public CreateDepartmentItemDTO CreateDepartmentItemDTO { get; set; }
}