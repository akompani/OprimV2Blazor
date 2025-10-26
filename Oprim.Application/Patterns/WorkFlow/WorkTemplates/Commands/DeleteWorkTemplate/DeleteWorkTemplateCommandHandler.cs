using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.WorkTemplates.Commands.DeleteWorkTemplate;

public class DeleteWorkTemplateCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteWorkTemplateCommand>
{
    public async Task Handle(DeleteWorkTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<WorkTemplate>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<WorkTemplate>().DeleteAsync(entity, cancellationToken);
    }
}