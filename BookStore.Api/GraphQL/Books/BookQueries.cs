using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Books.DataLoaders;
using BookStore.Api.Services;
using BookStore.Data.Models;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Books
{
  [ExtendObjectType(Name = "Query")]
  public class BookQueries
  {
    public async Task<Book?>
      GetBookById(Guid id, BookByIdDataLoader dataLoader, CancellationToken cancellationToken) =>
      await dataLoader.LoadAsync(id, cancellationToken);
  }
}