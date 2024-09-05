using System.ComponentModel.DataAnnotations;

namespace APIMTM.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public int Price { get; set; }
        public ICollection<BookAuthor>? BookList { get; set; }
    }
}
