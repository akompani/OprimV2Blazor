using MediatR;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Commands.DeleteProjectItem;

public class DeleteProjectItemCommand : IRequest
{
    public int Id { get; set; }
}