using MediatR;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Application.Patterns.PMO.Projects.Queries.GetProjects;

public class GetProjectsQuery:IRequest<List<Project>>
{
    
}