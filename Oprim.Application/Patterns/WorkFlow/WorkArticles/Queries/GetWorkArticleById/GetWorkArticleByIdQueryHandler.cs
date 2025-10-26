using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Queries.GetWorkArticleById;

public class GetWorkArticleByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetWorkArticleByIdQuery, WorkArticle>
{
    public async Task<WorkArticle> Handle(GetWorkArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.GenericRepository<WorkArticle>().TableNoTracking
            .AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    }
}