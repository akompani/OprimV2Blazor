using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.WorkFlow;

namespace Oprim.Application.Patterns.WorkFlow.Works.Commands.CreateWork;

public class CreateWorkCommandHandler(IUnitOfWork ofWork, IMapper mapper)
    : IRequestHandler<CreateWorkCommand>
{
    public async Task Handle(CreateWorkCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Work>(request.CreateWorkDto);
        await ofWork.GenericRepository<Work>().AddAsync(entity, cancellationToken);
    }
}