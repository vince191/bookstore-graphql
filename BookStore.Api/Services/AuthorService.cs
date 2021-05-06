using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.GraphQL.Authors.Inputs;
using BookStore.Api.GraphQL.Books.Inputs;
using BookStore.Data.Models;
using BookStore.Data.Repository;

namespace BookStore.Api.Services
{
  public interface IAuthorService
  {
    Task<Author> SaveAsync(AddAuthorInput input, CancellationToken cancellationToken = default);
    Task<Author?> UpdateAsync(UpdateAuthorInput input, CancellationToken cancellationToken = default);
  }

  public class AuthorService : IAuthorService
  {
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
      _authorRepository = authorRepository;
      _mapper = mapper;
    }

    public async Task<Author> SaveAsync(AddAuthorInput input, CancellationToken cancellationToken = default)
    {
      var newAuthor = _mapper.Map<Author>(input);
      return await _authorRepository.SaveAuthorAsync(newAuthor, cancellationToken);
    }

    public async Task<Author?> UpdateAsync(UpdateAuthorInput input, CancellationToken cancellationToken = default)
    {
      var author = await _authorRepository.GetAuthorByIdAsync(input.id, cancellationToken);

      if (author == null)
        return null;

      author = _mapper.Map<Author>(input);
      return await _authorRepository.UpdateAuthorAsync(author, cancellationToken);
    }
  }
}