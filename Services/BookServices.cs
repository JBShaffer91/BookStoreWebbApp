using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Services
{
    public class BookService
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
    }
}
