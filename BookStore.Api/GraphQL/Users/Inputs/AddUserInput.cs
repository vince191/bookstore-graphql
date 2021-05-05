using System;

namespace BookStore.Api.GraphQL.Users.Inputs
{
  public record AddUserInput(
    string email,
    string firstName,
    string lastName,
    DateTime DateOfBirth,
    bool active
  );
}