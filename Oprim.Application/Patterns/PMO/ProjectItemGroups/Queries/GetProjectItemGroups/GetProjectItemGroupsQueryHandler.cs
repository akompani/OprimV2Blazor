using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.PMO.ProjectItems.Queries.GetProjectItems;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Queries.GetProjectItemGroups;

public class GetProjectItemGroupsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectItemGroupsQuery, List<ProjectItemGroup>>
{
    public async Task<List<ProjectItemGroup>> Handle(GetProjectItemGroupsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectItemGroup>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}