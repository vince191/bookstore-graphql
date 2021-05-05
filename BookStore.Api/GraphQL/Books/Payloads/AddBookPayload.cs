using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Books.Payloads
{
  public class AddBookPayload : PayloadBase<Book>
  {
    public AddBookPayload(Book book) : base(book)
    {
    }

    public AddBookPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}