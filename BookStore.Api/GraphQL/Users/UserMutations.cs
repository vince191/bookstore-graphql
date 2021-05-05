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
      AddUserInput input)
    {
      var savedUser = await userService.SaveAsync(input);
      await eventSender.SendAsync(nameof(UserSubscriptions.OnUserAddedAsync), savedUser.Id);
      return new AddUserPayload(savedUser);
    }
  }
}