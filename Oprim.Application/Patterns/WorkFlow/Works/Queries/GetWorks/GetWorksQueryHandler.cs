using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Queries.GetWorks;

public class GetWorksQueryHandler(IUnitOfWork ofWork)
    : IRequestHandler<GetWorksQuery, List<Work>>
{
    public async Task<List<Work>> Handle(GetWorksQuery request,
        CancellationToken cancellationToken)
    {
        var query = ofWork.GenericRepository<Work>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}