using FeedbackService.Models;
using FeedbackService.DTO;

public interface IRepository
{
    Task<Feedback?> GetFeedback(int id);
    void CreateFeedback(FeedbackDTO feedbackDto);
    Task<bool> Save();
}
