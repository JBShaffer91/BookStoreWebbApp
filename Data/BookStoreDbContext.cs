using BookStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
