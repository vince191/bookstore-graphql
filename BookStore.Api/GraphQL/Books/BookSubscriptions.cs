using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Books.DataLoaders;
using BookStore.Data.Models;
using BookStore.Data.Repository;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Books
{
  [ExtendObjectType(Name = "Subscription")]
  public class BookSubscriptions
  {
    [Subscribe]
    [Topic]
    public Task<Book> OnBookAddedAsync(
      [EventMessage] Guid bookId,
      BookBatchDataLoader dataLoader,
      IResolverContext context,
      CancellationToken cancellationToken) =>
      dataLoader.LoadAsync(bookId, cancellationToken);
  }
}