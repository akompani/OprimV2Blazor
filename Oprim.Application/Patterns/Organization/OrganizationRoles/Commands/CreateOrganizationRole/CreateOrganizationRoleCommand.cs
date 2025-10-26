using MediatR;
using Oprim.Application.Dtos.Organization.OrganizationRoles;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Commands.CreateOrganizationRole;

public class CreateOrganizationRoleCommand : IRequest
{
    public CreateOrganizationRoleDTO CreateOrganizationRoleDto { get; set; }
}