using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.ProjectItems.Queries.GetProjectItemById;

public class GetProjectItemByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectItemByIdQuery, ProjectItem>
{
    public async Task<ProjectItem> Handle(GetProjectItemByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<ProjectItem>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}