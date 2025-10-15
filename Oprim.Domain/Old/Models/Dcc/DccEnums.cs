namespace Oprim.Domain.Old.Models.Dcc
{

    public static class DocumentGeneralFunctions
    {
        public const int ReportDocumentTypeId = -1;
        public const int SubcontractorStatementDocumentTypeId = -11;
        public const int InvoiceDocumentTypeId = -21;
    }

    //public enum DocumentCategories : byte
    //{
    //    [Display(Name = "PDR")]
    //    Report = 1,
    //    [Display(Name = "INV")]
    //    Invoice = 2,
    //    [Display(Name = "WDM")]
    //    WorkDoneMinute = 3,
    //    [Display(Name = "CWO")]
    //    ChangeWorkOrder = 4,
    //    [Display(Name = "CSC")]
    //    SubcontractorContract = 5,
    //    [Display(Name = "CSS")]
    //    SubcontractorStatement = 6,
    //    [Display(Name = "QPD")]
    //    Permit = 7,
    //    [Display(Name = "DWG")]
    //    Drawing = 8,
    //    [Display(Name = "SHP")]
    //    ShopDrawing = 9
    //}

    public enum ValidateSituations: byte
    {
        NoParameters=0,
        NotValid=1,
        Valid=2
    }

  
}
