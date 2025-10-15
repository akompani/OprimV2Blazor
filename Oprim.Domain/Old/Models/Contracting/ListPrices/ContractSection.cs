using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices.Classes;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractSection : ICacheModel
    {
        public ContractSection()
        {

        }

        public ContractSection(int projectId, int fieldId, byte fehrestFieldCode, short fehrestSectionCode, short code, string name, double overheadFactor)
        {
            string factorStr = GeneralFunctions.FactorsStr(overheadFactor);

            ProjectId = projectId;
            FieldId = fieldId;
            FehrestFieldCode = fehrestFieldCode;
            FehrestSectionCode = fehrestSectionCode;
            Code = code;
            Name = name;
            OverheadFactor = overheadFactor;
            EstimateFactor = 1;
            OfferFactor = 1;
            TotalEstimateFactor = overheadFactor;
            TotalEstimateFactorStr = factorStr;
            TotalOfferFactor = overheadFactor;
            TotalOfferFactorStr = factorStr;
            TotalStarFactor = 1;
            TotalStarFactorStr = factorStr;
            TotalFactorialFactor = overheadFactor;
            TotalFactorialFactorStr = factorStr;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("FieldId")] public ContractField? Field { get; set; }
        public int FieldId { get; set; }

        public byte FehrestFieldCode { get; set; }

        public short FehrestSectionCode { get; set; }

        public short Code { get; set; }

        public string Name { get; set; }

        [DefaultValue(1.41)]
        public double OverheadFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long NetAmount { get; set; }

        [DefaultValue(1)]
        public double EstimateFactor { get; set; }

        public string? EstimateFactorStr { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EstimateAmount { get; set; }

        [DefaultValue(1)]
        public double OfferFactor { get; set; }
        public string? OfferFactorStr { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long OfferAmount { get; set; }

        public double TotalEstimateFactor { get; set; }
        public string? TotalEstimateFactorStr { get; set; }

        public double TotalStarFactor { get; set; }
        public string? TotalStarFactorStr { get; set; }

        public double TotalFactorialFactor { get; set; }
        public string? TotalFactorialFactorStr { get; set; }

        public double TotalOfferFactor { get; set; }
        public string? TotalOfferFactorStr { get; set; }

        public bool IsEquipmentSection { get; set; }


        public string FullName
        {
            get
            {
                return $"فصل {SectionNameAndNumber}";
            }
        }

        public string GroupFullName
        {
            get
            {
                return $"{Field?.Name ?? ""} - {Name ?? ""}";
            }
        }

        public string SectionNameAndNumber
        {
            get { return $"{Code} - {Name}"; }
        }

        public double TotalSectionFactorByType(ItemTypes itemType)
        {
            switch (itemType)
            {
                case ItemTypes.Star:
                    return TotalStarFactor;

                case ItemTypes.Factori:
                    return TotalFactorialFactor;

                default:
                    return TotalOfferFactor;
            }
        }
        public string TotalSectionFactorStrByType(ItemTypes itemType)
        {
            switch (itemType)
            {
                case ItemTypes.Star:
                    return TotalStarFactorStr;

                case ItemTypes.Factori:
                    return TotalFactorialFactorStr;

                default:
                    return TotalOfferFactorStr;
            }
        }

        public void RefreshFactors()
        {
            TotalEstimateFactor = OverheadFactor * EstimateFactor;
            TotalEstimateFactorStr = GeneralFunctions.FactorsStr(OverheadFactor, EstimateFactorStr);

            TotalOfferFactor = TotalEstimateFactor * OfferFactor;
            TotalOfferFactorStr = GeneralFunctions.FactorsStr(OverheadFactor, EstimateFactorStr, OfferFactorStr);

            if (IsEquipmentSection)
            {
                EstimateFactor = 1;

                TotalEstimateFactor = 1;
                TotalEstimateFactorStr = "1";

                TotalOfferFactor = OfferFactor;
                TotalOfferFactorStr = OfferFactor.ToString();

                TotalStarFactor = 1;
                TotalStarFactorStr = "1";

                TotalFactorialFactor = 1;
                TotalFactorialFactorStr = "1";


                EstimateAmount = NetAmount;
                OfferAmount = (long)(NetAmount * OfferFactor);
            }
            else
            {
                EstimateAmount = (long)(NetAmount * TotalEstimateFactor);
                OfferAmount = (long)(NetAmount * TotalOfferFactor);
            }

        }

        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(ContractSection), ProjectId)};
        }
    }
}
