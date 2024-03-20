using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW00014039.Data;
using CW00014039.Models;
using CW00014039.Repositories;

namespace CW00014039.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackDbContext _context;
        private readonly IFeedbacksRepository _feedbacksRepository;

        public FeedbacksController(IFeedbacksRepository feedbacksRepository)
        {
            _feedbacksRepository = feedbacksRepository;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<IEnumerable<Feedback>>GetFeedbacks()
        {
            return await _feedbacksRepository.GetAllFeedbacks();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
         
            var feedback = await _feedbacksRepository.GetSingleFeedback(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        {
            if (id != feedback.ID)
            {
                return BadRequest();
            }
            await _feedbacksRepository.UpdateFeedback(feedback);


            return NoContent();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
        
            
            await _feedbacksRepository.CreateFeedback(feedback);

            return CreatedAtAction("GetFeedback", new { id = feedback.ID }, feedback);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
          await _feedbacksRepository.DeleteFeedback(id);

            return NoContent();
        }

       
    }
}
