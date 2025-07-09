using System.ComponentModel.DataAnnotations;

namespace FeedbackService.DTO
{
    public class FeedbackDTO
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }

        [Range(1, 5)]
        [Required]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }
    }
}
