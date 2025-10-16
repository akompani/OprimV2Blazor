using MediatR;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Quality;

namespace Oprim.Application.Patterns.Qualities.Commands.CreatePunchItem;

public class CreatePunchItemCommandHandler(IUnitOfWork ofWork) : IRequestHandler<CreatePunchItemCommand>
{
    public async Task Handle(CreatePunchItemCommand request, CancellationToken cancellationToken)
    {
        await ofWork.GenericRepository<PunchItem>().AddAsync(new PunchItem
        {
            CreateTime = request.CreateTime,
            CreatorId = request.CreatorId,
            OpponentLinks = request.OpponentLinks,
            ProjectId = request.ProjectId,
            DepartmentItemId = request.DepartmentItemId,
            Notes = request.Notes,
            ProjectItemId = request.ProjectItemId,
            WbsId = request.WbsId,
        }, cancellationToken);
    }
}