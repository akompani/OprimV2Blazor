using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Commands.DeleteStakeholder;

public class DeleteOrganizationRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrganizationRoleCommand>
{
    public async Task Handle(DeleteOrganizationRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenericRepository<OrganizationRole>().GetByIdAsync(cancellationToken, request.Id);
        await unitOfWork.GenericRepository<OrganizationRole>().DeleteAsync(entity, cancellationToken);
    }
}