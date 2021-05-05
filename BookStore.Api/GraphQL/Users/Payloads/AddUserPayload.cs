using System.Collections.Generic;
using BookStore.Api.GraphQL.Common;
using BookStore.Data.Models;

namespace BookStore.Api.GraphQL.Users.Payloads
{
  public class AddUserPayload : PayloadBase<User>
  {
    public AddUserPayload(User user) : base(user)
    {
    }

    public AddUserPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
  }
}