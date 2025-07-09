using FeedbackService.Models;
using FeedbackService.DTO;
using FeedbackService.Data;

public class FeedbackRepository : IRepository
{
    private readonly FeedbackServiceDbContext _context;

    public FeedbackRepository(FeedbackServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Feedback?> GetFeedback(int id)
    {
        return await _context.Feedbacks.FindAsync(id);
    }

    public void CreateFeedback(FeedbackDTO dto)
    {
        var feedback = new Feedback
        {
            UserId = dto.UserId,
            ItemId = dto.ItemId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        };

        _context.Feedbacks.Add(feedback);

        // create OutboxEvent here if desired
        var outbox = new OutboxEvent
        {
            EventType = "FeedbackSubmitted",
            Payload = System.Text.Json.JsonSerializer.Serialize(feedback),
            CreatedAt = DateTime.UtcNow,
            Processed = false
        };

        _context.OutboxEvents.Add(outbox);
    }

    public async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
