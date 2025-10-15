using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Payroll
{
    public class HumanPayrollBenefitArticle:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ArticleId")] public HumanPayrollArticle Article { get; set; }
        public long ArticleId { get; set; }

        [ForeignKey("BenefitTypeId")] public PayrollBenefitType BenefitType { get; set; }
        public int BenefitTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }


        public string[] DefaultCacheNames()
        {
            throw new NotImplementedException();
        }
    }
}
