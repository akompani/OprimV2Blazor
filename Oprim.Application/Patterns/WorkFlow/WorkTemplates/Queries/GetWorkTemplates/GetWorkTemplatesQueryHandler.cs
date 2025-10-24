using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Queries.GetWorkTemplates;

public class GetWorkTemplatesQueryHandler(IUnitOfWork ofWork)
    : IRequestHandler<GetWorkTemplatesQuery, List<WorkTemplate>>
{
    public async Task<List<WorkTemplate>> Handle(GetWorkTemplatesQuery request,
        CancellationToken cancellationToken)
    {
        var query = ofWork.GenericRepository<WorkTemplate>().TableNoTracking
            .Where(p => p.ProjectId == request.ProjectId)
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}