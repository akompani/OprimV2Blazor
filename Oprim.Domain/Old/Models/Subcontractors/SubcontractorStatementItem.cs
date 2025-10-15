using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorStatementItem: ICacheModel
    {

        [Key]
        public long Id { get; set; }

        public int Row { get; set; }

        [ForeignKey("StatementId")] public SubcontractorStatement? Statement { get; set; }
        public long StatementId { get; set; }

        [ForeignKey("ContractItemId")] public SubcontractorContractItem? ContractItem { get; set; }
        public long ContractItemId { get; set; }

        public double Quantity { get; set; }
        public double ApprovedQuantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public decimal QcFactor { get; set; }
        public decimal QaFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ApprovedAmount { get; set; }

        public string? Notes { get; set; }

        public void CopyValues(SubcontractorStatementItem source)
        {
            Quantity = source.Quantity;
            ApprovedQuantity = source.ApprovedQuantity;
            QaFactor = source.QaFactor;
            QcFactor = source.QcFactor;

            CalculateAmounts();
        }

        public void CalculateAmounts()
        {
            Amount =(long)( Quantity * Price);
            ApprovedAmount = (long)(ApprovedQuantity * Price * (double)( QaFactor * QcFactor));
        }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(SubcontractorStatementItem), StatementId) };
        }
    }
}
