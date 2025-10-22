using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Queries.GetProjectItemById;

public class GetProjectItemByIdQuery : IRequest<ProjectItem>
{
    public int Id { get; set; }
}