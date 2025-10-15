using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Communications
{
    public class NotificationLog:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("SenderId")] public Stakeholder? Sender { get; set; }
        public int SenderId { get; set; }

        [ForeignKey("ReceiverId")] public Stakeholder? Receiver { get; set; }
        public int ReceiverId { get; set; }

        [MaxLength(20)]
        public string SendTime { get; set; }

        [Required]
        public string Message { get; set; }

        [MaxLength(20)]
        public string? DeliverTime { get; set; }

        public int TryNumber { get; set; }

        public CommunicationModes CommunicationMode { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(NotificationLog), "NotDelivered"),
                ICacheModel.CreateCacheName(nameof(NotificationLog), SenderId),
                ICacheModel.CreateCacheName(nameof(NotificationLog), ReceiverId)
            };
        }
    }
}
