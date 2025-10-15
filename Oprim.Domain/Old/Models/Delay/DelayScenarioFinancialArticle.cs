using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayScenarioFinancialArticle : ICacheModel
    {
        public DelayScenarioFinancialArticle()
        {
        }

        public DelayScenarioFinancialArticle(int scenarioId,int invoiceTypeId,long invoiceId,long paymentId, string name, long amount,int duration, string sendDate, string effectiveDate, string actualPaymentDate)
        {
            ScenarioId = scenarioId;
            InvoiceTypeId = invoiceTypeId;
            Name = name;
            Amount = amount;
            Duration = duration;
            SendDate = sendDate;
            EffectiveDate = effectiveDate;
            ActualPaymentDate = actualPaymentDate;
            InvoiceId = invoiceId;
            PaymentId = paymentId;
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ScenarioId")] public DelayScenario Scenario { get; set; }
        public int ScenarioId { get; set; }

        public int InvoiceTypeId { get; set; }
        public long InvoiceId { get; set; }
        public long PaymentId { get; set; }

        public int Row { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string SendDate { get; set; }

        public string EffectiveDate { get; set; }

        public string ActualPaymentDate { get; set; }

        public int Duration { get; set; }

        public int DelayDays { get; set; }

        public int ContinuousDays { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(DelayScenarioFinancialArticle), ScenarioId)
            };
        }
    }
}
