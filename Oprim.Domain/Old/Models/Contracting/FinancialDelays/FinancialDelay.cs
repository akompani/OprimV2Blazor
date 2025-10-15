using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    [Index(nameof(ProjectId),nameof(Order),nameof(FinishPeriodDate),IsUnique = true)]
    public class FinancialDelay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public byte Order { get; set; }

        public string StartPeriodDate { get; set; }    
        
        public string EffectiveTarikh { get; set; }

        public int EffectiveDuration { get; set; }

        [MaxLength(10)]
        public string FinishPeriodDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public double DeltaS { get; set; }
        public double FailureRatio { get; set; }
        public int ApproveDuration { get; set; }

        public string ApproveDate { get; set; }

        public bool NextStep { get; set; }

        public int PrevDuration { get; set; }
        

        [MaxLength(20)]
        public string CalculationTime { get; set; }


        public List<FinancialDelayInvoiceArticle> FinancialDelayInvoiceArticles;
        public List<FinancialDelayPaymentArticle> FinancialDelayPaymentArticles;
        public List<FinancialDelayOverlapArticle> FinancialDelayOverlapArticles;

    }
}
