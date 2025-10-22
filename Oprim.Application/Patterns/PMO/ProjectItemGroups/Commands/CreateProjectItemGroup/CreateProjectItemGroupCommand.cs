using MediatR;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Commands.CreateProjectItemGroup;

public class CreateProjectItemGroupCommand : IRequest
{
    public string Name { get; set; }
}