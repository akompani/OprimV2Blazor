using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Queries.GetStakeholderGroupById;

public class GetStakeholderGroupByIdQuery : IRequest<StakeholderGroup>
{
    public int Id { get; set; }
}