using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    [Index(nameof(ProjectId), nameof(FieldId), nameof(Code), IsUnique = true)]
    public class ContractItem : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("FieldId")] public ContractField Field { get; set; }
        public int FieldId { get; set; }

        [ForeignKey("SectionId")] public ContractSection Section { get; set; }
        public int SectionId { get; set; }

        public string Code { get; set; }

        public ItemTypes ItemType { get; set; }
        
        public string Name { get; set; }

        public string SubName { get; set; }

        public string Unit { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Price { get; set; }

        public EscalationPeriodModes EscalationMode { get; set; }
        
        public double EstimateQuantity { get; set; }

        public double TotalFactor
        {
            get
            {
                return this.Section?.TotalSectionFactorByType(ItemType) ?? 1;
            }
        }
        public string TotalFactorStr
        {
            get
            {
                return this.Section?.TotalSectionFactorStrByType(ItemType) ?? "";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(ContractItem), ProjectId) };
        }
    }
}
