using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Application.Patterns.Scope.ProjectDepartmentItems.Queries.GetDepartmentItems;

public class GetDepartmentItemsQueryHandler(IUnitOfWork ofWork)
    : IRequestHandler<GetDepartmentItemsQuery, List<ProjectDepartmentItem>>
{
    public async Task<List<ProjectDepartmentItem>> Handle(GetDepartmentItemsQuery request,
        CancellationToken cancellationToken)
    {
        var query = ofWork.GenericRepository<ProjectDepartmentItem>().TableNoTracking
            .Where(p => p.ProjectId == request.ProjectId)
            .AsNoTracking();

        if (request.ProjectDepartmentId != 0) query = query.Where(p => p.ProjectId == request.ProjectDepartmentId);

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}