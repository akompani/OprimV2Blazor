using MediatR;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Commands.DeleteProjectItem;

public class DeleteProjectItemGroupCommand : IRequest
{
    public int Id { get; set; }
}