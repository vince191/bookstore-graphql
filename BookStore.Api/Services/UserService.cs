using System.Threading.Tasks;
using AutoMapper;
using BookStore.Api.GraphQL.Users.Inputs;
using BookStore.Data.Models;
using BookStore.Data.Repository;

namespace BookStore.Api.Services
{
  public interface IUserService
  {
    Task<User> SaveAsync(AddUserInput input);
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

    public async Task<User> SaveAsync(AddUserInput input)
    {
      var newUser = _mapper.Map<User>(input);
      return await _userRepository.SaveUserAsync(newUser);
    }
  }
}