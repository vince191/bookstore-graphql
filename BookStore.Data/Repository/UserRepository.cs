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
  public interface IUserRepository
  {
    IQueryable<User> GetUsersByIdAsync(IReadOnlyList<Guid> ids);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User> SaveUserAsync(User user, CancellationToken cancellationToken = default);
    Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken = default);
  }

  public class UserRepository : IUserRepository
  {
    private readonly BookStoreContext _context;

    public UserRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<User> GetUsersByIdAsync(IReadOnlyList<Guid> ids)
    {
      return _context.Users.Where(x => ids.Any(id => id == x.Id));
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
      return await _context.Users.FirstOrDefaultAsync(book => book.Id == id, cancellationToken);
    }

    public async Task<User> SaveUserAsync(User user, CancellationToken cancellationToken = default)
    {
      user.DateCreated = DateTime.Now;
      await _context.Users.AddAsync(user, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);
      return user;
    }

    public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken = default)
    {
      _context.Users.Update(user);
      await _context.SaveChangesAsync(cancellationToken);
      return user;
    }
  }
}