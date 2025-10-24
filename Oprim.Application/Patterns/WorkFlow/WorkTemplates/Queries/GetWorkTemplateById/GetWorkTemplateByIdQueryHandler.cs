using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Queries.GetWorkTemplateById;

public class GetWorkTemplateByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetWorkTemplateByIdQuery, WorkTemplate>
{
    public async Task<WorkTemplate> Handle(GetWorkTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<WorkTemplate>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}