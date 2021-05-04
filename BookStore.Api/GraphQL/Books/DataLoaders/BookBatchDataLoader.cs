using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Data.Models;
using BookStore.Data.Repository;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.GraphQL.Books.DataLoaders
{
  public class BookBatchDataLoader : BatchDataLoader<Guid, Book>
  {
    private readonly IBookRepository _repository;

    public BookBatchDataLoader(
      IBookRepository repository,
      IBatchScheduler batchScheduler,
      DataLoaderOptions<Guid>? options = null)
      : base(batchScheduler, options)
    {
      _repository = repository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, Book>> LoadBatchAsync(
      IReadOnlyList<Guid> keys,
      CancellationToken cancellationToken)
    {
      // instead of fetching one book, we fetch multiple books
      var books = _repository.GetBooksById(keys);
      return await books.ToDictionaryAsync(x => x.Id, cancellationToken);
    }
  }
}