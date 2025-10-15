namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class OrganizationChartElementViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int TopRoleId { get; set; }

        public List<OrganizationChartElementViewModel> Children { get; set; } =
            new List<OrganizationChartElementViewModel>();
    }
}
