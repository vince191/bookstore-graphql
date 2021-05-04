using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.GraphQL.Books.Inputs;
using BookStore.Data.Models;
using BookStore.Data.Repository;

namespace BookStore.Api.Services
{
  public interface IBookService
  {
    Task<Book> SaveAsync(AddBookInput input);
  }

  public class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
      _bookRepository = bookRepository;
      _mapper = mapper;
    }
 
    public async Task<Book> SaveAsync(AddBookInput input)
    {
      var newBook = _mapper.Map<Book>(input);
      return await _bookRepository.SaveBookAsync(newBook);
    }
  }
}