using System;

namespace AngularTest.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int Rank { get; set; }
        public Guid BookListId { get; set; }
        public BookList BookList { get; set; }
    }
}
