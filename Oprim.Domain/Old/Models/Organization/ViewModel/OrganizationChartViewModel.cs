using GeneralServices.Tree;

namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class OrganizationChartViewModel
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }

        public TreeNode[] Nodes { get; set; }
    }
}
