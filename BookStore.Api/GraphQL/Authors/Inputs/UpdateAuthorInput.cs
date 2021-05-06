using System;

namespace BookStore.Api.GraphQL.Authors.Inputs
{
  public record UpdateAuthorInput(
    Guid id,
    string email,
    string firstName,
    string lastName,
    string profileImage,
    DateTime dateOfBirth,
    bool active
  );
}