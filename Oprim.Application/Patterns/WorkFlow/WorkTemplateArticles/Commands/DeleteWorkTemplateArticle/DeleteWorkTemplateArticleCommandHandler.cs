using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplateArticles.Commands.DeleteWorkTemplateArticle;

public class DeleteWorkTemplateArticleCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteWorkTemplateArticleCommand>
{
    public async Task Handle(DeleteWorkTemplateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<WorkTemplateArticle>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<WorkTemplateArticle>().DeleteAsync(entity, cancellationToken);
    }
}