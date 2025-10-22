using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Queries.GetProjectItemGroups;

public class GetProjectItemGroupsQuery:IRequest<List<ProjectItemGroup>>
{
    
}