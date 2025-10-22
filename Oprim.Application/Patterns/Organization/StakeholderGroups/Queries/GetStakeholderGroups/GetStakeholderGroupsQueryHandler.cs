using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Queries.GetStakeholderGroups;

public class GetStakeholderGroupsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStakeholderGroupsQuery, List<StakeholderGroup>>
{
    public async Task<List<StakeholderGroup>> Handle(GetStakeholderGroupsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<StakeholderGroup>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}