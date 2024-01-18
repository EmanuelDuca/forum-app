using Domain.DTOs;
using Domain.Models;

namespace BlazorWasm.Services;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId, 
        string? titleContains, 
        string? descriptionContains
    );

    Task<Post> GetByIdAsync(int id);
}