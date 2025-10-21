using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Projects.Queries.GetProjects;
using Oprim.Domain.Entities.Projects;

namespace Oprim.Application.Patterns.Qualities.Queries.GetPunches;

public class GetProjectsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectsQuery, List<Project>>
{
    public async Task<List<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<Project>().TableNoTracking
            .AsNoTracking();

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}