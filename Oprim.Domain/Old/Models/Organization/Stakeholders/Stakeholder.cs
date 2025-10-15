using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Organization.Stakeholders
{
    [Index(nameof(Code), IsUnique = true)]
    public class Stakeholder : ICacheModel, ISummarize
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        [Required]
        public string Code { get; set; }

        [ForeignKey("StakeholderGroupId")] public StakeholderGroup? StakeholderGroup { get; set; }
        public int StakeholderGroupId { get; set; }

        public PersonalityTypes PersonalityType { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public string IdentifyCode { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Phone]
        public string? FaxNumber { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        public string Address { get; set; }

        [MaxLength(20)]
        public string? ZipCode { get; set; }

        public string SubName
        {
            get
            {
                return FullName.Substring(0, 1);
            }
        }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(Stakeholder) };
        }
        
        public SummarizeTemplate GetSummarize()
        {
            return new SummarizeTemplate(Id, FullName);
        }
    }
}
