using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Dcc.FileManager
{
    public class FileModel: ICacheModel
    {
        public FileModel()
        {

        }

        public FileModel(int projectId, int fileTypeId, int creatorId, IFormFile file,string fileId = null, string description = null)
        {
            ProjectId = projectId;
            FileTypeId = fileTypeId;
            CreatorId = creatorId;
            
            CreateTime = PersianDateTime.Now.FullDateTime();
            Description = description;
            Size = file.Length;
            FileName = file.FileName;

            FileId = string.IsNullOrEmpty(fileId) ? Guid.NewGuid().ToString() : fileId;
            Extension = Path.GetExtension(file.FileName);
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("FileTypeId")] public FileType FileType { get; set; }
        public int FileTypeId { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        [MaxLength(20)]
        public string CreateTime { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public long Size { get; set; }

        public string FileName { get; set; }

        public string FileId { get; set; }

        [MaxLength(10)]
        public string Extension { get; set; }

        public string GetFilePath
        {
            get
            {
                return FileId + Extension;
            }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(FileModel), ProjectId)};
        }
    }
}
