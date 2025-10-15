using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Organization
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [MaxLength(20)]
        public string RegisterTime { get; set; }
        
        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public string FullName
        {
            get
            {
                return Stakeholder?.FullName ?? "";
            }
        }
    }
}
