using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectByIdQuery, Project>
{
    public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<Project>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}