using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Commands.CreateOrganizationRole;

public class CreateOrganizationRoleCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    : IRequestHandler<CreateOrganizationRoleCommand>
{
    public async Task Handle(CreateOrganizationRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<OrganizationRole>(request.CreateOrganizationRoleDto);
        await unitOfWork.GenericRepository<OrganizationRole>().AddAsync(entity, cancellationToken);
    }
}