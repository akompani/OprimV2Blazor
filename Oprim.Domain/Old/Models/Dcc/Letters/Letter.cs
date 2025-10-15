using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Dcc.Letters
{
    public class Letter:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("LetterGroupId")] public LetterGroup LetterGroup { get; set; }
        public int LetterGroupId { get; set; }

        [ForeignKey("LetterSubjectGroupId")] public LetterSubjectGroup LetterSubjectGroup { get; set; }
        public int LetterSubjectGroupId { get; set; }

        public string Code { get; set; }

        public long NextLetterId { get; set; }

        public long FollowLetterId { get; set; }

        [MaxLength(100)]
        public string Subject { get; set; }

        public string OpponentLinks { get; set; }

        public string WbsLinks { get; set; }
        
        public string SendDate { get; set; }
        public string CreateDate { get; set; }

        public string SubjectSubText { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(Letter), ProjectId)};
        }

        public string FullName
        {
            get
            {
                return $"{Code} - {Subject}";
            }
        }

    }
}
