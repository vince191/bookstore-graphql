using System;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Api.GraphQL.Users.Inputs;
using BookStore.Api.GraphQL.Users.Payloads;
using BookStore.Api.Services;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Users
{
  [ExtendObjectType(Name = "Mutation")]
  public class UserMutations
  {
    public async Task<AddUserPayload> AddUserAsync(
      [Service] IUserService userService,
      [Service] ITopicEventSender eventSender,
      AddUserInput input,
      CancellationToken cancellationToken)
    {
      var savedUser = await userService.SaveAsync(input, cancellationToken);
      if (savedUser == null)
      {
        throw new ArgumentNullException(nameof(savedUser),
          "Saved user got a null from Save of UserService. Saving user failed.");
      }

      await eventSender.SendAsync(nameof(UserSubscriptions.OnUserAddedAsync), savedUser.Id, cancellationToken);
      return new AddUserPayload(savedUser);
    }

    public async Task<UpdateUserPayload> UpdateUserAsync(
      [Service] IUserService userService,
      [Service] ITopicEventSender eventSender,
      UpdateUserInput input,
      CancellationToken cancellationToken)
    {
      var savedUser = await userService.UpdateAsync(input, cancellationToken);

      if (savedUser == null)
      {
        throw new ArgumentNullException(nameof(savedUser),
          "Saved user got a null from Update of UserService. Updating user failed.");
      }

      await eventSender.SendAsync(nameof(UserSubscriptions.OnUserUpdatedAsync), savedUser.Id, cancellationToken);
      return new UpdateUserPayload(savedUser);
    }
  }
}