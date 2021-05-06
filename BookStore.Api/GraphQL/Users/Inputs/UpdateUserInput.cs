using System;

namespace BookStore.Api.GraphQL.Users.Inputs
{
  public record UpdateUserInput(
    Guid id,
    string email,
    string firstName,
    string lastName,
    DateTime DateOfBirth,
    bool active
  );
}