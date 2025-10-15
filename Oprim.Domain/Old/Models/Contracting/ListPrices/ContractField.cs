using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractField:ICacheModel
    {
        public ContractField()
        {
            
        }

        public ContractField(byte fieldCode, string name)
        {
            FehrestFieldCode = fieldCode;
            Name = name;
        }

        [Key] public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public byte FehrestFieldCode { get; set; }

        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(ContractField), ProjectId) };
        }
    }
}
