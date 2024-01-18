namespace Domain.DTOs;

public class PostCreationDto
{
    public string UserName { get; }
    public string Title { get; }
    public string Description { get; }

    public PostCreationDto(string userName, string title, string description)
    {
        UserName = userName;
        Title = title;
        Description = description;
    }
}