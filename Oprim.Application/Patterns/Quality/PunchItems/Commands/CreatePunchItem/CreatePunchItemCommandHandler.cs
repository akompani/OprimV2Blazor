using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;

public class CreatePunchItemCommandHandler(IUnitOfWork ofWork) : IRequestHandler<CreatePunchItemCommand>
{
    public async Task Handle(CreatePunchItemCommand request, CancellationToken cancellationToken)
    {
        await ofWork.GenericRepository<PunchItem>().AddAsync(new PunchItem
        {
            CreateTime = request.CreateTime,
            OpponentLinks = request.OpponentLinks,
            Notes = request.Notes,
        }, cancellationToken);
    }
}