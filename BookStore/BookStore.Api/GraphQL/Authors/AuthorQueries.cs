using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Authors.DataLoaders;
using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Authors
{
  [ExtendObjectType(Name ="Query")]
  public class AuthorQueries
  {
    public async Task<Author>
      GetAuthor(Guid id, AuthorBatchDataLoader dataLoader, CancellationToken cancellationToken) =>
      await dataLoader.LoadAsync(id, cancellationToken);
  }
}