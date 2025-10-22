using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Queries.GetStakeholderGroups;

public class GetStakeholderGroupsQuery:IRequest<List<StakeholderGroup>>
{
    
}