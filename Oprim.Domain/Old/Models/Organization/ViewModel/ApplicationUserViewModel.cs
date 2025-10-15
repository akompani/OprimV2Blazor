using Oprim.Domain.Old.Security;

namespace Oprim.Domain.Old.Models.Organization.ViewModel
{
    public class ApplicationUserViewModel:ApplicationUser
    {
        public IEnumerable<OprimUserRole> Roles { get; set; }
    }
}
