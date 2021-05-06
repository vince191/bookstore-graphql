using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Authors.Payloads
{
  public class UpdateAuthorPayload : PayloadBase<Author>
  {
    public UpdateAuthorPayload(Author author) : base(author)
    {
    }

    public UpdateAuthorPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}