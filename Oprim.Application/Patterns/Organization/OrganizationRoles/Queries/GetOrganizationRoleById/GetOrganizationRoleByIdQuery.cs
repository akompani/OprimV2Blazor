using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Queries.GetOrganizationRoleById;

public class GetOrganizationRoleByIdQuery : IRequest<OrganizationRole>
{
    public int Id { get; set; }
}