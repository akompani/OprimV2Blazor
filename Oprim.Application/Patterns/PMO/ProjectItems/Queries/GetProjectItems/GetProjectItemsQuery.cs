using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Queries.GetProjectItems;

public class GetProjectItemsQuery:IRequest<List<ProjectItem>>
{
    public int ProjectId { get; set; }
}