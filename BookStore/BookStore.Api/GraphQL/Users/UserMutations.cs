using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Users
{
  [ExtendObjectType(typeof(User), Name = "Mutation")]
  public class UserMutations
  {
    
  }
}