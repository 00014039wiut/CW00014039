using CW00014039.Data;
using CW00014039.Models;
using Microsoft.EntityFrameworkCore;

namespace CW00014039.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly FeedbackDbContext _dbContext;

        public AuthorsRepository(FeedbackDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetSingleAuthor(int id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAuthor(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAuthor(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}

