using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    public class FinancialDelayGuaranteeInvoice
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public int No { get; set; }

        public string FreezeDate { get; set; }

        public string ToDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string Notes { get; set; }
    }
}
