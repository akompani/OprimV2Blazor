using Oprim.Domain.Old.Models.Dcc.DocumentTypes;

namespace Oprim.Domain.Old.Models.Dcc.Documents.ViewModel
{
    public class DocumentBaseViewModel:DocumentBase
    {
        public List<DocumentBaseParameter> Parameters { get; set; } = new List<DocumentBaseParameter>();
    }
}
