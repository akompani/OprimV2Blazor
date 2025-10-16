using MediatR;
using Microsoft.EntityFrameworkCore;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Qualities.Commands.DeletePunchItem;

public class DeletePunchItemCommandHandler(IUnitOfWork ofWork) : IRequestHandler<DeletePunchItemCommand>
{
    public async Task Handle(DeletePunchItemCommand request, CancellationToken cancellationToken)
    {
        var punchItem = await ofWork.GenericRepository<PunchItem>().Table.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (punchItem == null)
            return;
        await ofWork.GenericRepository<PunchItem>().DeleteAsync(punchItem, cancellationToken);
    }
}