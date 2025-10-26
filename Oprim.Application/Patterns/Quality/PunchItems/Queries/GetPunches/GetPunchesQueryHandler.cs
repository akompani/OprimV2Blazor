using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;

public class GetPunchesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPunchesQuery, List<PunchItem>>
{
    public async Task<List<PunchItem>> Handle(GetPunchesQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<PunchItem>().TableNoTracking
            .Include(x=>x.DepartmentItem)
            .Where(p=> p.DepartmentItem.ProjectId == request.ProjectId)
            .AsNoTracking();

        //if(request.DepartmentItemId != 0) query = query.Where(p=> p.d)
        
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}