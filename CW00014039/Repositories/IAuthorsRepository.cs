using CW00014039.Models;

namespace CW00014039.Repositories
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetSingleAuthor(int id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);


    }
}
