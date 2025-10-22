using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<Project>
{
    public int Id { get; set; }
}