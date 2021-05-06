using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Users.Payloads
{
  public class UpdateUserPayload : PayloadBase<User>
  {
    public UpdateUserPayload(User user) : base(user)
    {
    }

    public UpdateUserPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}