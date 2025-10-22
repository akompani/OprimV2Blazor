using MediatR;
using Oprim.Domain.Entities.Organization;

namespace Oprim.Application.Patterns.Organization.Stakeholders.Queries.GetStakeholderById;

public class GetStakeholderByIdQuery : IRequest<Stakeholder>
{
    public int Id { get; set; }
}