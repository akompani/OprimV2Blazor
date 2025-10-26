using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunchById;

public class GetPunchByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPunchByIdQuery, PunchItem>
{
    public async Task<PunchItem> Handle(GetPunchByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<PunchItem>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}