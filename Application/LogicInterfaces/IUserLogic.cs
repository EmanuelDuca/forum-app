using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userCreationDto);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetById(int id);
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDto searchParameters);
}