using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Context;
using BookStore.Data.Models;

namespace BookStore.Data.Repository
{
  public interface IAuthorRepository
  {
    public IQueryable<Author> GetAuthorsById(IReadOnlyList<Guid> ids);
    public Task<Author> SaveAuthorAsync(Author author);
  }

  public class AuthorRepository : IAuthorRepository
  {
    private readonly BookStoreContext _context;

    public AuthorRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<Author> GetAuthorsById(IReadOnlyList<Guid> ids)
    {
      return _context.Authors.Where(x => ids.Any(id => id == x.Id));
    }

    public async Task<Author> SaveAuthorAsync(Author author)
    {
      author.DateCreated = DateTime.Now;
      await _context.Authors.AddAsync(author);
      await _context.SaveChangesAsync();
      return author;
    }
  }
}