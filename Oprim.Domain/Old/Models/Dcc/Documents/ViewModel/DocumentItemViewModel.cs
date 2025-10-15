 using Oprim.Domain.Old.Models.Contracting;

 namespace Oprim.Domain.Old.Models.Dcc.Documents.ViewModel
{
    public class DocumentItemViewModel : DocumentItem
    {
        public string FieldName { get; set; }

        public int SectionNo { get; set; }

        public string SectionName { get; set; }

        public string ItemName { get; set; }

        public string ItemSubName { get; set; }

        public ItemTypes ItemType { get; set; }

        public string UnitName { get; set; }

        public long Price { get; set; }

    }
}
