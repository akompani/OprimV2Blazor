using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdowns;

public class GetProjectCostBreakdownsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectCostBreakdownsQuery, List<ProjectCostBreakdown>>
{
    public async Task<List<ProjectCostBreakdown>> Handle(GetProjectCostBreakdownsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectCostBreakdown>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}