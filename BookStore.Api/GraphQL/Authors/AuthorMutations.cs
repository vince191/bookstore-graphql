using System;
using System.Threading;
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
      AddAuthorInput input,
      CancellationToken cancellationToken)
    {
      var savedAuthor = await authorService.SaveAsync(input, cancellationToken);
      if (savedAuthor == null)
      {
        throw new ArgumentNullException(nameof(savedAuthor),
          "Saved author got a null from Save of AuthorService. Saving author failed.");
      }
      await eventSender.SendAsync(nameof(AuthorSubscriptions.OnAuthorAddedAsync), savedAuthor.Id, cancellationToken);
      return new AddAuthorPayload(savedAuthor);
    }
    
    public async Task<UpdateAuthorPayload> UpdateAuthorAsync(
      [Service] IAuthorService authorService,
      [Service] ITopicEventSender eventSender,
      UpdateAuthorInput input,
      CancellationToken cancellationToken)
    {
      var savedAuthor = await authorService.UpdateAsync(input, cancellationToken);

      if (savedAuthor == null)
      {
        throw new ArgumentNullException(nameof(savedAuthor),
          "Saved author got a null from Update of AuthorService. Updating author failed.");
      }

      await eventSender.SendAsync(nameof(AuthorSubscriptions.OnAuthorUpdatedAsync), savedAuthor.Id, cancellationToken);
      return new UpdateAuthorPayload(savedAuthor);
    }
  }
}