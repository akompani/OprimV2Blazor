using MediatR;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Commands.DeleteProjectItem;

public class DeleteProjectItemGroupCommand : IRequest
{
    public int Id { get; set; }
}