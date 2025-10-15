using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentItemSummary : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        public string Name { get; set; }

        public string RefreshTarikh { get; set; }

        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(DocumentItemSummary), ProjectId)};
        }
    }
}
