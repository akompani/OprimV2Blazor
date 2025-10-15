using GeneralServices.Models.Weather;
using Oprim.Domain.Old.Models.Dcc.Documents;
using Oprim.Domain.Old.Models.WorkFlow.ViewModel;

namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class PersonalDashboardViewModel
    {
        public WeatherForecast WeatherForecast { get; set; }

        public List<WorkArticleViewModel> WorkArticles { get; set; }

        public List<Document> OwnedDocuments { get; set; }

        public List<string> ShortcutList { get; set; }

        public List<WorkBaseStakeholderSummary> DocumentTypeStakeholderSummaries { get; set; }

        public int UnCompletedArticles { get; set; }
    }
}
