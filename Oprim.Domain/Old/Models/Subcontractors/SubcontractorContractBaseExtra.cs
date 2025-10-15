using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Contracting;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    [Index(nameof(Name), IsUnique = true)]
    public class SubcontractorContractBaseExtra: ICacheModel
    {
        public SubcontractorContractBaseExtra()
        {

        }

        public SubcontractorContractBaseExtra(int documentTypeId
            , InvoiceExtraTypes extraType
            , string name
            , double percentage = 0
            , long fixAmount = 0
            , double maxLimitPercentage = 0
            , long maxLimitFixAmount = 0)
        {
            ExtraType = extraType;
            Name = name;
            Percentage = percentage;
            FixAmount = fixAmount;
            MaxLimitPercentage = maxLimitPercentage;
            MaxLimitFixAmount = maxLimitFixAmount;
        }

        [Key]
        public int Id { get; set; }

       public InvoiceExtraTypes ExtraType { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public double Percentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FixAmount { get; set; }

        public double MaxLimitPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long MaxLimitFixAmount { get; set; }

        public string[] DefaultCacheNames() => new[] { nameof(SubcontractorContractBaseExtra)};

    }
}
