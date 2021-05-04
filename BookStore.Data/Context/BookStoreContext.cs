using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
  public class BookStoreContext : DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<BookRating> BookRatings { get; set; }
    public DbSet<User> Users { get; set; }

    public BookStoreContext(DbContextOptions options)
      : base(options)
    {
    }
  }
}