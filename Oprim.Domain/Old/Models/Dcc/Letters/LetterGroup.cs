using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Dcc.Letters
{
    public class LetterGroup: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "دسته بندی نامه")]
        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(LetterGroup) };
        }
    }
}
