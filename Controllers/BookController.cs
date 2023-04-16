using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookStoreWebApp.Services;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /Book
        public IActionResult Index()
        {
          List<Book> books = _bookService.GetBooks();
          return View(books);
        }
    }
}
