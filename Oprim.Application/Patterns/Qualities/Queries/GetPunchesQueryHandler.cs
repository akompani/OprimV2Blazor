using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Qualities.Queries;

public class GetPunchesQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPunchesQuery, List<PunchItem>>
{
    public async Task<List<PunchItem>> Handle(GetPunchesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<PunchItem>().TableNoTracking
            .Include(p => p.ProjectWbs)
            .Include(p => p.DepartmentItem)
            .Include(p => p.Creator)
            .AsQueryable();

        query = query.Where(p => p.ProjectId == request.DepartmentItemId);


        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}