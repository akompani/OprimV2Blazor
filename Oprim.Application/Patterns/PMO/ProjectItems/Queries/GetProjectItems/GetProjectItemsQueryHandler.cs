using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Queries.GetProjectItems;

public class GetProjectItemsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetProjectItemsQuery, List<ProjectItem>>
{
    public async Task<List<ProjectItem>> Handle(GetProjectItemsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectItem>().TableNoTracking
            .Include(x => x.ProjectItemGroup)
            .Where(p => p.ProjectItemGroup.ProjectId == request.ProjectId)
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}