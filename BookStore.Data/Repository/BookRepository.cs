using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Context;
using BookStore.Data.Models;

namespace BookStore.Data.Repository
{
  public interface IBookRepository
  {
    public IQueryable<Book> GetBooksById(IReadOnlyList<Guid> ids);
    public Task<Book> SaveBookAsync(Book book);
  }

  public class BookRepository : IBookRepository
  {
    private readonly BookStoreContext _context;

    public BookRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<Book> GetBooksById(IReadOnlyList<Guid> ids)
    {
      return _context.Books;
    }

    public async Task<Book> SaveBookAsync(Book book)
    {
      book.DateCreated = DateTime.Now;
      await _context.Books.AddAsync(book);
      await _context.SaveChangesAsync();
      return book;
    }
  }
}