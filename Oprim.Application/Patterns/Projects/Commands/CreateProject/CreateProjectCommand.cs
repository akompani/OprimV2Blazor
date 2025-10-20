using MediatR;
using Oprim.Application.Dtos.Project;
using Oprim.Domain.Entities.Projects;

namespace Oprim.Application.Patterns.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest
{
    public CreateProjectDTO CreateProjectDto { get; set; }
}