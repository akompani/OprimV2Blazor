using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Queries.GetStakeholders;

public class GetStakeholdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStakeholdersQuery, List<Stakeholder>>
{
    public async Task<List<Stakeholder>> Handle(GetStakeholdersQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<Stakeholder>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}