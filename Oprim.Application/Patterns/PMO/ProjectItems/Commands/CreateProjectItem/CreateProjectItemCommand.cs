using MediatR;
using Oprim.Application.Dtos.Project;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Commands.CreateProjectItem;

public class CreateProjectItemCommand : IRequest
{
    public CreateProjectDTO CreateProjectDto { get; set; }
}