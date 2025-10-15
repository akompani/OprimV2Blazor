using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Dcc.FileManager
{
    public class FileGroup
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
