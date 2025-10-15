using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Dcc.FileManager
{
    public class FileType: ICacheModel
    {
        [Key]   
        public int Id { get; set; }

        public string Name { get; set; }

        public string Extensions { get; set; }

        public int MaxSize { get; set; }

        public string ExecuteProgram { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(FileType) };
        }
    }
}
