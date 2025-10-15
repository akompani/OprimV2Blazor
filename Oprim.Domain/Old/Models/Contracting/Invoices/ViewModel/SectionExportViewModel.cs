using Oprim.Domain.Old.Models.Contracting.ListPrices;

namespace Oprim.Domain.Old.Models.Contracting.Invoices.ViewModel
{
    public class SectionsExportViewModel 
    {

        public List<ContractSection> ProjectSections { get; set; }
       
        public double Balasary { get; set; }

        public double Tabaghat { get; set; }

        public double Ertefa { get; set; }

        public double Hard { get; set; }

        public double Engineer { get; set; }

        public double Pishnahad { get; set; }

        public double TotalFactor
        {
            get { return Math.Round(Balasary * Tabaghat * Ertefa * Hard * Engineer * Pishnahad,6);} }

        public string TotalFactorStr
        {
            get
            {
                return  Balasary.ToString() + "*" + Pishnahad.ToString() + "*" + Tabaghat.ToString() + "*" +
                       Ertefa.ToString() + "*" + Hard.ToString() + "*" + Engineer.ToString();
            }
        }
    }
}
