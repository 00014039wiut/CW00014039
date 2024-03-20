using System.ComponentModel.DataAnnotations;

namespace CW00014039.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name of the author is required")]
        public string FullName { get; set; }
    }
}
