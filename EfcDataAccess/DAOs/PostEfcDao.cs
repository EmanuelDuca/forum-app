using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newTodo = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newTodo.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        IQueryable<Post> query = context.Posts.AsQueryable();

        if (dto.UserId != null)
        {
            query = query.Where(p => p.UserId == dto.UserId);
        }

        if (!string.IsNullOrEmpty(dto.TitleContains))
        {
            query = query.Where(p =>
                p.Title.ToLower().Contains(dto.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        Post? found = await context.Posts
            .FirstOrDefaultAsync(post => post.Id == id);
        return found;
    }
}