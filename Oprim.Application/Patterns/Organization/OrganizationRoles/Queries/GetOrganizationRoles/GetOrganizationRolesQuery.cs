using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Queries.GetOrganizationRoles;

public class GetOrganizationRolesQuery : IRequest<List<OrganizationRole>>
{
    public int ProjectId { get; set; }
}