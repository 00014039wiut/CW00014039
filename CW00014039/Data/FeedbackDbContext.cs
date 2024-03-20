using CW00014039.Models;
using Microsoft.EntityFrameworkCore;

namespace CW00014039.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
