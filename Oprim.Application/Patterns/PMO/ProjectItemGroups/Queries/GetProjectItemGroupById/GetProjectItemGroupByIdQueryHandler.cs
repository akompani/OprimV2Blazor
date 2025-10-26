using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItemGroups.Queries.GetProjectItemGroupById;

public class GetProjectItemGroupByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectItemGroupByIdQuery, ProjectItemGroup>
{
    public async Task<ProjectItemGroup> Handle(GetProjectItemGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectItemGroup>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}