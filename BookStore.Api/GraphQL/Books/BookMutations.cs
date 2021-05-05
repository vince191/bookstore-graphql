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
      AddBookInput input)
    {
      var savedBook = await bookService.SaveAsync(input);
      await eventSender.SendAsync(nameof(BookSubscriptions.OnBookAddedAsync), savedBook.Id);
      return new AddBookPayload(savedBook);
    }
  }
}