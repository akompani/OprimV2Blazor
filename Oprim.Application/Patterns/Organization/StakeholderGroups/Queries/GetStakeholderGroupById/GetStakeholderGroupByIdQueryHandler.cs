using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.StakeholderGroups.Queries.GetStakeholderGroupById;

public class GetStakeholderGroupByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStakeholderGroupByIdQuery, StakeholderGroup>
{
    public async Task<StakeholderGroup> Handle(GetStakeholderGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<StakeholderGroup>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}