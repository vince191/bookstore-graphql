using AutoMapper;
using BookStore.Api.GraphQL.Books.Inputs;
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
      
    }
    
    private void AddUserMappings()
    {
      
    }
  }
}