using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;

public class CreatePunchItemCommandHandler(IUnitOfWork ofWork,IMapper mapper) : IRequestHandler<CreatePunchItemCommand>
{
    public async Task Handle(CreatePunchItemCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<PunchItem>(request.CreatePunchItemDTO);
        await ofWork.GenericRepository<PunchItem>().AddAsync(entity, cancellationToken);
    }
}