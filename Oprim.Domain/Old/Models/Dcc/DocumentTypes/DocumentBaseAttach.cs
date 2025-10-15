using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Roles;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentBaseAttach : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase? DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        [ForeignKey("OrganizationRoleId")] public OrganizationRole? OrganizationRole { get; set; }
        public int OrganizationRoleId { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(DocumentBaseAttach), DocumentBaseId)};
        }
    }
}
