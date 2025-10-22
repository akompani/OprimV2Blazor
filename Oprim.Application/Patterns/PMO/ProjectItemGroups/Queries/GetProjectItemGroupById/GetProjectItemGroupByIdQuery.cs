using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Queries.GetProjectItemGroupById;

public class GetProjectItemGroupByIdQuery : IRequest<ProjectItemGroup>
{
    public int Id { get; set; }
}