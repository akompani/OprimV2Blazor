using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Contracting
{

    public enum ContractTypes : byte
    {
        A = 1, //موافقتنامه ، شرایط عمومی و شرایط خصوص 
        B = 2, //ب : قرارداد همسان طرح و ساخت
        C = 3, // پ : تجمیع راه
        D = 4, // ت : سرجمع ساختمان
        E = 5, // ث : epc تامین کالا و نصب
        F = 6, // ج : ep
        G = 7, // چ : pc کالا
        H = 8, // ح : c صنعتی
        I = 9, // خ : خدمات مشاوره
        J = 10, // سایر موارد مشمول ماده 1 آیین نامه تضامین دولتی
    }

    public enum ContractSituations : byte
    {
        Ongoing = 1,
        Finalized = 2
    }

    public enum ContractStakeholderTypes : byte
    {
        Consultant = 1,
        Client = 2
    }

    public enum PlanTypes : byte
    {
        CivilBudget = 0,
        Other = 1
    }

    public enum SjAndStatementVersions : byte
    {
        [Display(Name = "پیمانکار")]
        Peymankar = 0,
        [Display(Name = "مشاور")]
        Moshaver = 1,
        [Display(Name = "کارفرما")]
        Karfarma = 2
    }

    public enum InvoiceCategory : byte
    {
        FirstDeposit = 1,
        NextDeposits = 2,
        Statement = 3,
        Escalation = 4,
        CurrencyEscalation = 5,
        MaterialEscalation = 6,
    }

    public enum InvoiceExtraTypes : byte
    {
        Addition = 1,
        Deduction = 2
    }

    public enum PaymentTypes : byte
    {
        OnGoing = 1,
        Deposit = 2,
        Clause81 = 3
    }

    public enum PaymentInputModes : byte
    {
        Net = 0,
        Gross = 1
    }

    public enum ItemTypes : byte
    {
        [Display(Name = "فهرست بها", Description = "")]
        Fehrest = 0,
        [Display(Name = "مبنای قرارداد", Description = "*ع")]
        Star = 1,
        [Display(Name = "قیمت جدید", Description = "*")]
        NewItem = 2,
        [Display(Name = "فاکتوری", Description = "ف")]
        Factori = 3,
    }

    public enum ItemFactorTypes : byte
    {
        //[Display(Name = "بالاسری")] Overhead = 1,
        [Display(Name = "طبقات")] Story = 2,
        [Display(Name = "ارتفاع")] Height = 3,
        [Display(Name = "صعوبت")] Difficulty = 4,
        [Display(Name = "مهندسی")] Engineering = 5,
        [Display(Name = "سایر")] Other = 6,
        [Display(Name = "پیشنهادی")] Offer = 8,
        [Display(Name = "تجهیز")] Equip = 9
    }

    public enum EscalationPeriodModes : byte
    {
        None = 0,
        Continuous = 1,
        OnFinish = 2
    }

    public enum OldMethodDelayTypes : byte
    {
        None = 0,
        FirstAdvancePayment = 1,
        NextAdvancePayment = 2,
        Statement = 3
    }
    public static class ContractingGeneralFunctions
    {
        public static string GetItemTypeSymbol(this ItemTypes itemType)
        {
            switch (itemType)
            {
                case ItemTypes.Fehrest:
                    return "ف";

                case ItemTypes.Star:
                    return "*ع";

                case ItemTypes.NewItem:
                    return "ج";

                case ItemTypes.Factori:
                    return "ا";

                default:
                    return "نامعلوم";

            }
        }

        public static string GetItemTypeName(this ItemTypes itemType)
        {
            switch (itemType)
            {
                case ItemTypes.Fehrest:
                    return "فهرست پایه";

                case ItemTypes.Star:
                    return "ستاره دار";

                case ItemTypes.NewItem:
                    return "قیمت جدید";

                case ItemTypes.Factori:
                    return "فاکتوری";

                default:
                    return "";

            }
        }

        public static string GetItemTypeDescription(this ItemTypes itemType)
        {
            switch (itemType)
            {
                case ItemTypes.Star:
                    return "ستاره دار";

                case ItemTypes.Factori:
                    return "فاکتوری";

                default:
                    return "";

            }
        }




    }

}
