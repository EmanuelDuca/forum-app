using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.UserName);
        if (user == null)
        {
            throw new Exception($"User with id {dto.UserName} was not found.");
        }
        
        ValidatePost(dto);
        Post post = new Post(user.Id, dto.Title, dto.Description);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        return postDao.GetAsync(dto);
    }

    public Task<Post> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }
}