using MediatR;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Commands.DeleteDepartmentItem;

public class DeleteDepartmentItemCommand:IRequest
{
    public int Id { get; set; }
}