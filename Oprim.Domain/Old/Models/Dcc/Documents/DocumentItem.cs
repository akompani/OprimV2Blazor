using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentItem : ICacheModel

    {
        public DocumentItem()
        {
        }

        public DocumentItem(DocumentItem obj, int row)
        {
            Row = row;
            BasicRow = obj.BasicRow;
            ItemId = obj.ItemId;
            Quantity = obj.Quantity;
            Amount = obj.Amount;
            Factor = obj.Factor;
            FactoredAmount = obj.FactoredAmount;
        }

        public DocumentItem(int documentId, int row, int prevArticleRow, bool basicRow,
            int itemId, double quantity, long amount, double factor, long factoredAmount, long attachDocumentId)
        {
            Row = row;
            DocumentId=documentId;
            BasicRow = basicRow;
            ItemId =itemId;
            Quantity = quantity;
            Amount = amount;
            Factor = factor;
            FactoredAmount = factoredAmount;
        }

        [Key] public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        public int Row { get; set; }

        public bool BasicRow { get; set; }

        [ForeignKey("ItemId")] public ContractItem Item { get; set; }
        public int ItemId { get; set; }

        public long PrevItemId { get; set; }

        public double N { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double T { get; set; }

        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public double Factor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long FactoredAmount { get; set; }

        public void CalculateAmount()
        {
            Amount = (long)((Item?.Price ?? 0) * Quantity);
            Factor = Item?.TotalFactor ?? 0;
            FactoredAmount = (long)(Factor * Amount);
        }

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(DocumentItem), ArticleId) };
    }
}
