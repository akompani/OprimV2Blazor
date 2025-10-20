using MediatR;
using Oprim.Domain.Entities.Projects;

namespace Oprim.Application.Patterns.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<Project>
{
    public int Id { get; set; }
}