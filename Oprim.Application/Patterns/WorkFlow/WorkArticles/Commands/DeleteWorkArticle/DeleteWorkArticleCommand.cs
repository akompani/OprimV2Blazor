using MediatR;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Commands.DeleteWorkArticle;

public class DeleteWorkArticleCommand:IRequest
{
    public long Id { get; set; }
}