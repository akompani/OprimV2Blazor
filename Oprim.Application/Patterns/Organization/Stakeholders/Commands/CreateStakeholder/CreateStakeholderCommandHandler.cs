using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Commands.CreateStakeholder;

public class CreateStakeholderCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    : IRequestHandler<CreateStakeholderCommand>
{
    public async Task Handle(CreateStakeholderCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Stakeholder>(request.CreateStakeholderDto);
        await unitOfWork.GenericRepository<Stakeholder>().AddAsync(entity, cancellationToken);
    }
}