using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Users.DataLoaders;
using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Users
{
  [ExtendObjectType(Name = "Query")]
  public class UserQueries
  {
    public async Task<User?>
      GetUserById(Guid id, UserBatchDataLoader dataLoader, CancellationToken cancellationToken) =>
      await dataLoader.LoadAsync(id, cancellationToken);
  }
}