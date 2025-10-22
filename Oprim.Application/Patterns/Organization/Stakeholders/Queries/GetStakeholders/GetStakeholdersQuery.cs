using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Queries.GetStakeholders;

public class GetStakeholdersQuery:IRequest<List<Stakeholder>>
{
    
}