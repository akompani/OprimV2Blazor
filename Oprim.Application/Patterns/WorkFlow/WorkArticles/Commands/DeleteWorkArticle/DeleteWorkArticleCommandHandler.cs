using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkArticles.Commands.DeleteWorkArticle;

public class DeleteWorkArticleCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteWorkArticleCommand>
{
    public async Task Handle(DeleteWorkArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<WorkArticle>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<WorkArticle>().DeleteAsync(entity, cancellationToken);
    }
}