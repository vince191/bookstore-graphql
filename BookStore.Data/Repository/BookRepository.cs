using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Data.Context;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
  public interface IBookRepository
  {
    IQueryable<Book> GetBooksByIdAsync(IReadOnlyList<Guid> ids);
    Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Book> SaveBookAsync(Book book, CancellationToken cancellationToken = default);
    Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken = default);
  }

  public class BookRepository : IBookRepository
  {
    private readonly BookStoreContext _context;

    public BookRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<Book> GetBooksByIdAsync(IReadOnlyList<Guid> ids)
    {
      return _context.Books.Where(x => ids.Any(id => id == x.Id));
    }

    public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
      return await _context.Books.FirstOrDefaultAsync(book => book.Id == id, cancellationToken);
    }

    public async Task<Book> SaveBookAsync(Book book, CancellationToken cancellationToken = default)
    {
      book.DateCreated = DateTime.Now;
      await _context.Books.AddAsync(book, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);
      return book;
    }

    public async Task<Book> UpdateBookAsync(Book book, CancellationToken cancellationToken = default)
    {
      _context.Books.Update(book);
      await _context.SaveChangesAsync(cancellationToken);
      return book;
    }
  }
}