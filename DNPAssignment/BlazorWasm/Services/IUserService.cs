using Domain.DTOs;
using Domain.Models;

namespace BlazorWasm.Services;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
    Task<User> GetUserById(int id);
}