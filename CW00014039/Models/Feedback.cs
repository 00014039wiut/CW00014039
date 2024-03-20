using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW00014039.Models
{
    public class Feedback
    {
        [Required]
        public int ID { get; set; }

        [Required (ErrorMessage = " Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
