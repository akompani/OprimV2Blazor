using MediatR;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Commands.DeleteStakeholder;

public class DeleteOrganizationRoleCommand : IRequest
{
    public int Id { get; set; }
}