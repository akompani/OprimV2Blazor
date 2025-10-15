using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.Invoices
{
    public class Invoice : ICacheModel,ISummarize
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long DocumentId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [ForeignKey("InvoiceTypeId")] public InvoiceType InvoiceType { get; set; }
        public int InvoiceTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long CumulativeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long ConfirmedCumulativeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long PeriodAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long DeductionAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long AdditionAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long DelayEffectiveAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        [DefaultValue(0)]
        public long PayableAmount { get; set; }        
        
       

        [MaxLength(10)]
        public string StartPeriodDate { get; set; }

        [MaxLength(10)]
        public string FinishPeriodDate { get; set; }

        [MaxLength(10)]
        public string SendDate { get; set; }
                
        [MaxLength(10)]
        public string AllowDate { get; set; }

        public double Factor { get; set; }

        [MaxLength(10)]
        public string EffectiveDelayDate { get; set; }

        public bool Paid { get; set; }

        [MaxLength(10)]
        public string? EffectiveTime { get; set; }

        public string GetDisplayName()
        {
            return InvoiceType.InvoiceCategory switch
            {
                InvoiceCategory.Statement => $"دوره {StartPeriodDate} - {FinishPeriodDate}",
                InvoiceCategory.Escalation => $"تاریخ مجاز : {AllowDate} ضریب تعدیل : {Factor}",
                _ => ""
            };
        }

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(this.GetType().Name, ProjectId) };
        
        public SummarizeTemplate GetSummarize() => new SummarizeTemplate(Id, Name);

        public int Duration
        {
            get
            {
                return (FinishPeriodDate.ToPersianDateTime() - StartPeriodDate.ToPersianDateTime()).Days;
            }
        }

    }
}
