using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Post(int userId, string title, string description)
    {
        UserId = userId;
        Title = title;
        Description = description;
    }
    
    private Post() {}
}