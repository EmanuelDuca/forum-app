namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? Username { get;}
    public int? UserId { get;}
    public string? TitleContains { get;}
    public string? DescriptionContains { get;}
    
    public SearchPostParametersDto(string? username, int? userId, string? titleContains, string? descriptionContains)
    {
        Username = username;
        UserId = userId;
        TitleContains = titleContains;
        DescriptionContains = descriptionContains;
    }
}