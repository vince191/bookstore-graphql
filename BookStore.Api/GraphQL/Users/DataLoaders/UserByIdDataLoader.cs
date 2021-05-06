using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Data.Models;
using BookStore.Data.Repository;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.GraphQL.Users.DataLoaders
{
  public class UserByIdDataLoader : BatchDataLoader<Guid, User>
  {
    private readonly IUserRepository _repository;

    public UserByIdDataLoader(
      IUserRepository repository,
      IBatchScheduler batchScheduler,
      DataLoaderOptions<Guid>? options = null)
      : base(batchScheduler, options)
    {
      _repository = repository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, User>> LoadBatchAsync(
      IReadOnlyList<Guid> keys,
      CancellationToken cancellationToken)
    {
      // instead of fetching one user, we fetch multiple user
      var users = _repository.GetUsersByIdAsync(keys);
      return await users.ToDictionaryAsync(x => x.Id, cancellationToken);
    }
  }
}