using Microsoft.EntityFrameworkCore;

using FeedbackService.Models;
namespace FeedbackService.Data
{
    public class FeedbackServiceDbContext : DbContext
    {
        public FeedbackServiceDbContext(DbContextOptions<FeedbackServiceDbContext> options) : base(options)
        {
        }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<OutboxEvent> OutboxEvents { get; set; }
    }
}
