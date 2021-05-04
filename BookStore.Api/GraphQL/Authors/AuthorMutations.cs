using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Authors
{
  [ExtendObjectType(typeof(Author), Name = "Mutation")]
  public class AuthorMutations
  {
  }
}