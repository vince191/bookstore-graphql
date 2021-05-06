using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Users.DataLoaders;
using BookStore.Data.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Users
{
  [ExtendObjectType(Name = "Subscription")]
  public class UserSubscriptions
  {
    [Subscribe]
    [Topic]
    public Task<User> OnUserAddedAsync(
      [EventMessage] Guid userId,
      UserByIdDataLoader dataLoader,
      IResolverContext context,
      CancellationToken cancellationToken) =>
      dataLoader.LoadAsync(userId, cancellationToken);

    [Subscribe]
    [Topic]
    public Task<User> OnUserUpdatedAsync(
      [EventMessage] Guid userId,
      UserByIdDataLoader dataLoader,
      IResolverContext context,
      CancellationToken cancellationToken) =>
      dataLoader.LoadAsync(userId, cancellationToken);
  }
}