namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollArticleViewModel: HumanPayrollArticle
    {
        public int StakeholderId { get; set; }

        public string StakeholderName { get; set; }

        public string ContractName { get; set; }


        public string MonthNoName { get; set; }
    }
}
