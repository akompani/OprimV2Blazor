namespace Oprim.Domain.Old.Models.PMO.Cost.ViewModel
{
    public class ProjectCbsViewModel:ProjectCbs
    {
        public ProjectCbsViewModel TopLevel { get; set; }

        public string FullName
        {
            get
            {
                string topName = TopLevel == null ? "" : (TopLevel?.FullName ?? "");
                if (topName.Length > 0) topName += " - ";

                return topName + Name;
            }
        }
    }
}
