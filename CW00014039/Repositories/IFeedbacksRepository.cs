using CW00014039.Models;

namespace CW00014039.Repositories
{
    public interface IFeedbacksRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetSingleFeedback(int id);
        Task CreateFeedback(Feedback feedback);
        Task UpdateFeedback(Feedback feedback);
        Task DeleteFeedback(int id);


    }
}
