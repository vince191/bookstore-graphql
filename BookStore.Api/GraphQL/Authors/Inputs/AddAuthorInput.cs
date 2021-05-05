using System;

namespace BookStore.Api.GraphQL.Authors.Inputs
{
  public record AddAuthorInput(
    string email,
    string firstName,
    string lastName,
    string profileImage,
    DateTime dateOfBirth,
    bool active
  );
}