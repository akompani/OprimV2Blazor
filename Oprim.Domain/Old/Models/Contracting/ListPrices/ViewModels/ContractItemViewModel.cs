namespace Oprim.Domain.Old.Models.Contracting.ListPrices.ViewModels
{
    public class ContractItemViewModel:ContractItem
    {
        public List<ContractItemMaterial> ContractItemMaterials { get; set; }
        public List<ContractItemResource> ContractItemHumanResources { get; set; }
        public List<ContractItemResource> ContractItemMachineryResources { get; set; }

        public long HumanAmount
        {
            get
            {
                return ContractItemHumanResources.Sum(c => c.Amount);
            }
        }
        public long MachineryAmount
        {
            get
            {
                return ContractItemMachineryResources.Sum(c => c.Amount);
            }
        }
        public long MaterialAmount
        {
            get
            {
                return ContractItemMaterials.Sum(c => c.Amount);
            }
        }    
        
        public long TotalAmount
        {
            get
            {
                return HumanAmount + MachineryAmount + MaterialAmount;
            }
        }
    }
}
