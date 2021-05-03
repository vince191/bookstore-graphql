using BookStore.Data.Models;
using HotChocolate.Types;

namespace BookStore.Api.GraphQL.Books
{
  [ExtendObjectType(typeof(Book), Name = "Mutation")]
  public class BookMutations
  {
    
  }
}