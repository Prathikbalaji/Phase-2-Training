using System.ComponentModel.DataAnnotations;

namespace APIMTM.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public ICollection<BookAuthor>? Books { get; set; }

    }
}
