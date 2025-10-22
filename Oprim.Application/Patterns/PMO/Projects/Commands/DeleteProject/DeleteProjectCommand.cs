using MediatR;

namespace Oprim.Application.Patterns.PMO.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public int Id { get; set; }
}