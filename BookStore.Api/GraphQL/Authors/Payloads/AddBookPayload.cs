using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Authors.Payloads
{
  public class AddAuthorPayload : PayloadBase<Author>
  {
    public AddAuthorPayload(Author author) : base(author)
    {
    }

    public AddAuthorPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}