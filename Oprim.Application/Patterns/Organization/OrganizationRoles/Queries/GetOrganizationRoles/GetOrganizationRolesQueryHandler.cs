using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.OrganizationRoles.Queries.GetOrganizationRoles;

public class GetOrganizationRolesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetOrganizationRolesQuery, List<OrganizationRole>>
{
    public async Task<List<OrganizationRole>> Handle(GetOrganizationRolesQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<OrganizationRole>().TableNoTracking
            .Where(o=> o.ProjectId == request.ProjectId)
            .AsNoTracking();
        
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}