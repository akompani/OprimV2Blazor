namespace Oprim.Application.Dtos.PMO.ProjectItem;

public class CreateProjectItemDTO
{
    public int ProjectCbsId { get; set; }
    
    public string Code { get; set; }

    public string Name { get; set; }

    public int EngineeringLead { get; set; }

    public int ProcurementLead { get; set; }

    public string? Unit { get; set; }
}