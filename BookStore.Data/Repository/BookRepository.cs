using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Context;
using BookStore.Data.Models;

namespace BookStore.Data.Repository
{
  public interface IBookRepository
  {
    public IQueryable<Book> GetBooksById(IReadOnlyList<Guid> ids);
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
      return _context.Books.Where(x => x.Active);
    }
  }
}