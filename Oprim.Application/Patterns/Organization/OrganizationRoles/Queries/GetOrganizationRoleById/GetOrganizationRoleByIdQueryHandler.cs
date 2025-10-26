using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Queries.GetOrganizationRoleById;

public class GetOrganizationRoleByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrganizationRoleByIdQuery, OrganizationRole>
{
    public async Task<OrganizationRole> Handle(GetOrganizationRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<OrganizationRole>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}