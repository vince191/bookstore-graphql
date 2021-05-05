using System.Threading.Tasks;
using BookStore.Api.GraphQL.Authors.Inputs;
using BookStore.Api.GraphQL.Authors.Payloads;
using BookStore.Api.Services;
using BookStore.Data.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Authors
{
  [ExtendObjectType(Name = "Mutation")]
  public class AuthorMutations
  {
    public async Task<AddAuthorPayload> AddAuthorAsync(
      [Service] IAuthorService authorService,
      [Service] ITopicEventSender eventSender,
      AddAuthorInput input)
    {
      var savedAuthor = await authorService.SaveAsync(input);
      await eventSender.SendAsync(nameof(AuthorSubscriptions.OnAuthorAddedAsync), savedAuthor.Id);
      return new AddAuthorPayload(savedAuthor);
    }
  }
}