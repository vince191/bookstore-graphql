using AutoMapper;
using BookStore.Api.GraphQL.Authors.Inputs;
using BookStore.Api.GraphQL.Books.Inputs;
using BookStore.Api.GraphQL.Users.Inputs;
using BookStore.Data.Models;

namespace BookStore.Api.Core
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      AddBookMappings();
      AddAuthorMappings();
      AddUserMappings();
    }

    private void AddBookMappings()
    {
      CreateMap<AddBookInput, Book>();
      CreateMap<Book, AddBookInput>();
    }

    private void AddAuthorMappings()
    {
      CreateMap<AddAuthorInput, Author>();
      CreateMap<Author, AddAuthorInput>();
    }

    private void AddUserMappings()
    {
      CreateMap<AddUserInput, User>();
      CreateMap<User, AddUserInput>();
    }
  }
}