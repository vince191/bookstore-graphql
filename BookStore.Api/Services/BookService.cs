using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.GraphQL.Books.Inputs;
using BookStore.Data.Models;
using BookStore.Data.Repository;

namespace BookStore.Api.Services
{
  public interface IBookService
  {
    Task<Book> SaveAsync(AddBookInput input, CancellationToken cancellationToken = default);
    Task<Book?> UpdateAsync(UpdateBookInput input, CancellationToken cancellationToken = default);
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

    public async Task<Book> SaveAsync(AddBookInput input, CancellationToken cancellationToken = default)
    {
      var newBook = _mapper.Map<Book>(input);
      return await _bookRepository.SaveBookAsync(newBook, cancellationToken);
    }

    public async Task<Book?> UpdateAsync(UpdateBookInput input, CancellationToken cancellationToken = default)
    {
      var book = await _bookRepository.GetBookByIdAsync(input.id, cancellationToken);

      if (book == null)
        return null;

      book = _mapper.Map<Book>(input);
      return await _bookRepository.UpdateBookAsync(book, cancellationToken);
    }
  }
}