using CW00014039.Data;
using CW00014039.Models;
using Microsoft.EntityFrameworkCore;

namespace CW00014039.Repositories
{
    public class FeedbacksRepository : IFeedbacksRepository
    {
        private readonly FeedbackDbContext _dbContext;

        public FeedbacksRepository(FeedbackDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _dbContext.Feedbacks.Include(f=>f.Author).ToListAsync();
            return feedbacks;
        }

        public async Task<Feedback> GetSingleFeedback(int id)
        {
            return await _dbContext.Feedbacks.Include(f => f.Author).FirstOrDefaultAsync(f => f.ID == id);
        }
        public async Task CreateFeedback(Feedback feedback)
        {
            await _dbContext.Feedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(f => f.ID == id);
            if (feedback != null)
            {
                _dbContext.Feedbacks.Remove(feedback);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateFeedback(Feedback feedback)
        {
            _dbContext.Entry(feedback).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
