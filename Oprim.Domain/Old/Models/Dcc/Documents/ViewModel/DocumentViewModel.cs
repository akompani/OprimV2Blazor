using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.WorkFlow.ViewModel;

namespace Oprim.Domain.Old.Models.Dcc.Documents.ViewModel
{
    public class DocumentViewModel:Document
    {
        public ProjectItem? ProjectItem { get; set; }

        public ProjectDepartmentItem? DepartmentItem { get; set; }

        public ProjectWbs? ProjectWbs { get; set; }

        public ProjectChange? ProjectChange { get; set; }

        public WorkViewModel? WorkViewModel { get; set; }

        public Dictionary<DocumentBaseParameter, object> Parameters = new Dictionary<DocumentBaseParameter, object>();


        public List<DocumentFileAttach> AttachFiles { get; set; }
    }
}
