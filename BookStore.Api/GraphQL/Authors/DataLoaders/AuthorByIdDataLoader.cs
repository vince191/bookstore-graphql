using System;
using System.Collections.Generic; 
using System.Threading;
using System.Threading.Tasks;
using BookStore.Data.Models;
using BookStore.Data.Repository;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.GraphQL.Authors.DataLoaders
{
  public class AuthorByIdDataLoader : BatchDataLoader<Guid, Author>
  {
    private readonly IAuthorRepository _repository;

    public AuthorByIdDataLoader(
      IAuthorRepository repository,
      IBatchScheduler batchScheduler,
      DataLoaderOptions<Guid>? options = null)
      : base(batchScheduler, options)
    {
      _repository = repository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(
      IReadOnlyList<Guid> keys,
      CancellationToken cancellationToken)
    {
      // instead of fetching one author, we fetch multiple authors
      var authors = _repository.GetAuthorsById(keys);
      return await authors.ToDictionaryAsync(x => x.Id, cancellationToken);
    }
  }
}