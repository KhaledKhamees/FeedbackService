using Microsoft.AspNetCore.Mvc;
using FeedbackService.Data;
using FeedbackService.DTO;

namespace FeedbackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRepository _repository;

        public FeedbackController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var feedback = await _repository.GetFeedback(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.CreateFeedback(feedbackDto);

            if (await _repository.Save())
            {
                // Ideally we fetch the created feedback from DB if you want to return it.
                return StatusCode(201);
            }

            return StatusCode(500, "Error saving feedback.");
        }
    }
}
