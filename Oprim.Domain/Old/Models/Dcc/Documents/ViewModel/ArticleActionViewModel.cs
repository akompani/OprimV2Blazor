using GeneralServices.Classes;

namespace Oprim.Domain.Old.Models.Dcc.Documents.ViewModel
{
    public class ArticleActionViewModel
    {
        public long ArticleId { get; set; }

        public string? Notes { get; set; }

        public bool CheckMode { get; set; }

        public bool Accept { get; set; } = true;
        
        public SevenPointLikertScale Score { get; set; } = SevenPointLikertScale.NotBad;

        public bool Divert { get; set; }
        public int DivertStakeholderId { get; set; }

        public string SubmitUrl { get; set; }

        public string RedirectUrl { get; set; }

    }
}
