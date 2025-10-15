using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class Document : ICacheModel
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public long WorkId { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [MaxLength(10)]
        public string DocumentDate { get; set; }

        [MaxLength(20)]
        public string CreateTime { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        public ValidateSituations ValidateSituation { get; set; }

        [MaxLength(10)]
        public string? StartDate { get; set; }

        [MaxLength(10)]
        public string? FinishDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ConfirmAmount { get; set; }

        public int ProjectItemId { get; set; }

        public long DepartmentItemId { get; set; }

        public long ProjectWbsId { get; set; }

        public long ProjectChangeId { get; set; }

        public string? ParameterValues { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long OverScopeAmount { get; set; }

        public int ItemsCount { get; set; }

        public string? SendDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ConfirmOverScopeAmount { get; set; }

        [MaxLength(10)]
        public string? ConfirmDate { get; set; }

        public string Fullname
        {
            get { return $"{Code} - {Name}"; }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(Document), ProjectId)};
        }
    }
}
