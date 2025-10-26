using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Commands.DeleteWork;

public class DeleteWorkCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeleteWorkCommand>
{
    public async Task Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
    {
        var entity = await ofWork.GenericRepository<Work>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            return;
        
        await ofWork.GenericRepository<Work>().DeleteAsync(entity, cancellationToken);
    }
}