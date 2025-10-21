using MediatR;
using Oprim.Domain.Entities.Projects;

namespace Oprim.Application.Patterns.Projects.Queries.GetProjects;

public class GetProjectsQuery:IRequest<List<Project>>
{
    
}