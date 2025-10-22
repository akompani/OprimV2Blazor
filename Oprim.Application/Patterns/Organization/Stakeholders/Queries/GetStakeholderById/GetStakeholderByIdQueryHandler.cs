using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Queries.GetStakeholderById;

public class GetStakeholderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStakeholderByIdQuery, Stakeholder>
{
    public async Task<Stakeholder> Handle(GetStakeholderByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<Stakeholder>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}