using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Context;
using BookStore.Data.Models;

namespace BookStore.Data.Repository
{
  public interface IUserRepository
  {
    public IQueryable<User> GetUsersById(IReadOnlyList<Guid> ids);
    public Task<User> SaveUserAsync(User user);
  }

  public class UserRepository : IUserRepository
  {
    private readonly BookStoreContext _context;

    public UserRepository(BookStoreContext context)
    {
      _context = context;
    }

    public IQueryable<User> GetUsersById(IReadOnlyList<Guid> ids)
    {
      return _context.Users.Where(x => ids.Any(id => id == x.Id));
    }

    public async Task<User> SaveUserAsync(User user)
    {
      user.DateCreated = DateTime.Now;
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
      return user;
    }
  }
}