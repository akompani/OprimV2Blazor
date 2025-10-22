using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;

namespace Oprim.Domain.Entities.Organization;

public class Stakeholder : BaseEntity
{
    public string Code { get; set; }

    [ForeignKey("StakeholderGroupId")] public StakeholderGroup StakeholderGroup { get; set; }
    public int StakeholderGroupId { get; set; }

    public bool IsLegalPersonality { get; set; }
    
    public string FullName { get; set; }
    
    public string? IdentifyCode { get; set; }
    
    public string? Email { get; set; }
    
    public string? MobileNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }
    
    public string? Country { get; set; }
    
    public string? City { get; set; }

    public string? Address { get; set; }

    public string? ZipCode { get; set; }

}