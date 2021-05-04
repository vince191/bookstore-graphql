using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Users
{
  [ExtendObjectType(typeof(User), Name = "Subscription")]
  public class UserSubscriptions
  {
  }
}