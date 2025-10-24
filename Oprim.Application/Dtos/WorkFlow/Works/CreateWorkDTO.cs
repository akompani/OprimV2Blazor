using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.WorkFlow.Works;

public class CreateWorkDTO : BaseProjectDTO
{
    public long ProjectCalendarId { get; set; }
    
    public long WorkTemplateId { get; set; }

    public string Name { get; set; }
}