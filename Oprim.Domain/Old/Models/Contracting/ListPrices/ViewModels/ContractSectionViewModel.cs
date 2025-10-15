using MrMetrorGeneralServices.Models.Fehrest;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices.ViewModels
{
    public class ContractSectionViewModel:ContractSection
    {
        public FehrestField? FehrestField { get; set; }
        public FehrestSection? FehrestSection { get; set; }
    }
}
