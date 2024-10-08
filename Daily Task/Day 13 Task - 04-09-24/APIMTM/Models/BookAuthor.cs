﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APIMTM.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
