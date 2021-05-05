using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Authors.DataLoaders;
using BookStore.Data.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Authors
{
  [ExtendObjectType(Name = "Subscription")]
  public class AuthorSubscriptions
  {
    [Subscribe]
    [Topic]
    public Task<Author> OnAuthorAddedAsync(
      [EventMessage] Guid authorId,
      AuthorByIdDataLoader dataLoader,
      IResolverContext context,
      CancellationToken cancellationToken) =>
      dataLoader.LoadAsync(authorId, cancellationToken);
  }
}