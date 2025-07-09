using System.ComponentModel.DataAnnotations;

namespace FeedbackService.Models
{
    public class OutboxEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string EventType { get; set; } = string.Empty;
        [Required]
        public string Payload { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool? Processed { get; set; }
    }
}
