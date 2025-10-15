using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting;
using Oprim.Domain.Old.Models.Organization;
using Oprim.Domain.Old.Models.Organization.Roles;
using Oprim.Domain.Old.Models.Organization.Roles.ViewModel;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Projects
{
    public class Project: ICacheModel
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }


        [MaxLength(10)]  //TOS-ARG
        public string Code { get; set; }

        public string No { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ClientName { get; set; }

        public string CompanyName { get; set; }

        public string ContractDate { get; set; }

        public string StartDate { get; set; }

        public bool Lock { get; set; }

        public string FinishDate { get; set; }

        public int ContractTime { get; set; }

        public int ContractContinuousDays { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BaseAmount { get; set; }

        public PlanTypes PlanType { get; set; }

       public string ConsultantName { get; set; }

        public bool IsFehrestic { get; set; }

        public int FehrestYear { get; set; }

        public bool Tadil { get; set; }

        public int TadilBasePeriod { get; set; }

        public int TajhizFieldCode { get; set; }

        [Range(3, 5)]
        public byte TadilDecimal { get; set; }

        [DefaultValue(1.41)]
        public double OverheadFactor { get; set; }

        public string OfferDate { get; set; }

        [DefaultValue(1)]
        public double OfferFactor { get; set; }

        public bool Apply76574 { get; set; }

        [DefaultValue(3)]
        public ComponentTypes ComponentType { get; set; }

        public string LastUpdateProgress { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                nameof(Project),
                "ProjectSession",
                nameof(ComponentRole),
                nameof(ProjectRoleViewModel)
            };
        }
    }

}
