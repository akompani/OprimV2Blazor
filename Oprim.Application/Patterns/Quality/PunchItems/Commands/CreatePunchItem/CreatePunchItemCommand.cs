using MediatR;
using Oprim.Application.Dtos.Quality.PunchItem;

namespace Oprim.Application.Patterns.Quality.PunchItems.Commands.CreatePunchItem;

public class CreatePunchItemCommand:IRequest
{
    public CreatePunchItemDTO CreatePunchItemDTO { get; set; }
   
}