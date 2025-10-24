using MediatR;
using Oprim.Application.Dtos.PMO.Project;

namespace Oprim.Application.Patterns.PMO.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest
{
    public CreateProjectDTO CreateProjectDto { get; set; }
}