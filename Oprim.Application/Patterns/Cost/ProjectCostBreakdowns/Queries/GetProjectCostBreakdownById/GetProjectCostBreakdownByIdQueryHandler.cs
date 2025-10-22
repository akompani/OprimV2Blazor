using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdownById;

public class GetProjectCostBreakdownByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectCostBreakdownByIdQuery, ProjectCostBreakdown>
{
    public async Task<ProjectCostBreakdown> Handle(GetProjectCostBreakdownByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectCostBreakdown>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}