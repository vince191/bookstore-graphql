using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Books.Payloads
{
  public class UpdateBookPayload : PayloadBase<Book>
  {
    public UpdateBookPayload(Book book) : base(book)
    {
    }

    public UpdateBookPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}