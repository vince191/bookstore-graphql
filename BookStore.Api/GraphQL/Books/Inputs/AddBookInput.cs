using System;

namespace BookStore.Api.GraphQL.Books.Inputs
{
  public record AddBookInput(
    string title,
    string description,
    string coverImage,
    string iSBN13,
    string iSBN10,
    int price,
    DateTime releaseDate,
    bool active
  );
}