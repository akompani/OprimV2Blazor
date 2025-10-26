using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Queries.GetWorkById;

public class GetWorkByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetWorkByIdQuery, Work>
{
    public async Task<Work> Handle(GetWorkByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<Work>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}