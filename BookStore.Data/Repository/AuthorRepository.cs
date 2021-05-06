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
  public interface IAuthorRepository
  {
    IQueryable<Author> GetAuthorsByIdAsync(IReadOnlyList<Guid> ids);
    Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Author> SaveAuthorAsync(Author author, CancellationToken cancellationToken = default);
    Task<Author> UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default);
  }

  public class AuthorRepository : IAuthorRepository
  {
    private readonly BookStoreContext _context;

    public AuthorRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<Author> GetAuthorsByIdAsync(IReadOnlyList<Guid> ids)
    {
      return _context.Authors.Where(x => ids.Any(id => id == x.Id));
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
      return await _context.Authors.FirstOrDefaultAsync(book => book.Id == id, cancellationToken);
    }

    public async Task<Author> SaveAuthorAsync(Author author, CancellationToken cancellationToken = default)
    {
      author.DateCreated = DateTime.Now;
      await _context.Authors.AddAsync(author, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);
      return author;
    }

    public async Task<Author> UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default)
    {
      _context.Authors.Update(author);
      await _context.SaveChangesAsync(cancellationToken);
      return author;
    }
  }
}