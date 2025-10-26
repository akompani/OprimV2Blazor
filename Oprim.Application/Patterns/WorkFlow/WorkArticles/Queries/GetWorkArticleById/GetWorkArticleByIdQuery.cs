using MediatR;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Queries.GetWorkArticleById;

public class GetWorkArticleByIdQuery:IRequest<WorkArticle>
{
    public long Id { get; set; }
}