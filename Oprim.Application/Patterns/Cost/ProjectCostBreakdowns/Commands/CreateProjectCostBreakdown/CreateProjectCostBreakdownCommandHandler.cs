using AutoMapper;
using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Cost;

namespace Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Commands.CreateProjectCostBreakdown;

public class CreateProjectCostBreakdownCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    : IRequestHandler<CreateProjectCostBreakdownCommand>
{
    public async Task Handle(CreateProjectCostBreakdownCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ProjectCostBreakdown>( request.CreateCostBreakdownDto);
        await unitOfWork.GenericRepository<ProjectCostBreakdown>().AddAsync(entity, cancellationToken);
    }
}