using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Context;
using BookStore.Data.Models;

namespace BookStore.Data.Repository
{
  public interface IUserRepository
  {
    public IQueryable<User> GetUsersById(IReadOnlyList<Guid> ids);
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
      return _context.Users.Where(x => x.Active);
    }
  }
}