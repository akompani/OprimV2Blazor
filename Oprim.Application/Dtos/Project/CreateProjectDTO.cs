using Oprim.Application.Dtos.Common;

namespace Oprim.Application.Dtos.Project;

public class CreateProjectDTO:BaseDTO
{
    public string Code { get; set; }
    
    public string Name { get; set; }

    public string No { get; set; }

    public DateTime ContractDate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }
}