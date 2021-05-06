using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Books.Inputs;
using BookStore.Api.GraphQL.Books.Payloads;
using BookStore.Api.Services;
using BookStore.Data.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Books
{
  [ExtendObjectType(Name = "Mutation")]
  public class BookMutations
  {
    public async Task<AddBookPayload> AddBookAsync(
      [Service] IBookService bookService,
      [Service] ITopicEventSender eventSender,
      AddBookInput input,
      CancellationToken cancellationToken)
    {
      var savedBook = await bookService.SaveAsync(input, cancellationToken);

      if (savedBook == null)
      {
        throw new ArgumentNullException(nameof(savedBook),
          "Saved book got a null from Save of BookService. Saving book failed.");
      }

      await eventSender.SendAsync(nameof(BookSubscriptions.OnBookAddedAsync), savedBook.Id, cancellationToken);
      return new AddBookPayload(savedBook);
    }

    public async Task<UpdateBookPayload> UpdateBookAsync(
      [Service] IBookService bookService,
      [Service] ITopicEventSender eventSender,
      UpdateBookInput input,
      CancellationToken cancellationToken)
    {
      var savedBook = await bookService.UpdateAsync(input, cancellationToken);

      if (savedBook == null)
      {
        throw new ArgumentNullException(nameof(savedBook),
          "Saved book got a null from Update of BookService. Updating book failed.");
      }

      await eventSender.SendAsync(nameof(BookSubscriptions.OnBookUpdatedAsync), savedBook.Id, cancellationToken);
      return new UpdateBookPayload(savedBook);
    }
  }
}