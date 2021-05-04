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
  public class UserBatchDataLoader : BatchDataLoader<Guid, User>
  {
    private readonly IUserRepository _repository;

    public UserBatchDataLoader(
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
      // instead of fetching one author, we fetch multiple authors
      var users = _repository.GetUsersById(keys);
      return await users.ToDictionaryAsync(x => x.Id, cancellationToken);
    }
  }
}