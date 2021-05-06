using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.GraphQL.Users.Inputs;
using BookStore.Data.Models;
using BookStore.Data.Repository;

namespace BookStore.Api.Services
{
  public interface IUserService
  {
    Task<User> SaveAsync(AddUserInput input, CancellationToken cancellationToken = default);
    Task<User?> UpdateAsync(UpdateUserInput input, CancellationToken cancellationToken = default);
  }

  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<User> SaveAsync(AddUserInput input, CancellationToken cancellationToken = default)
    {
      var newUser = _mapper.Map<User>(input);
      return await _userRepository.SaveUserAsync(newUser, cancellationToken);
    }
    
    public async Task<User?> UpdateAsync(UpdateUserInput input, CancellationToken cancellationToken = default)
    {
      var user = await _userRepository.GetUserByIdAsync(input.id, cancellationToken);

      if (user == null)
        return null;

      user = _mapper.Map<User>(input);
      return await _userRepository.UpdateUserAsync(user, cancellationToken);
    }
  }
}