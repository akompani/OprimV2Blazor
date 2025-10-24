using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Queries.GetWorkArticles;

public class GetWorkArticlesQuery:IRequest<List<WorkArticle>>
{
    public long ProjectId { get; set; }
    public long WorkId { get; set; }
}