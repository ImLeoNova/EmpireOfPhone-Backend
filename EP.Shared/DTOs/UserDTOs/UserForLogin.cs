namespace EP.Shared.DTOs.UserDTOs;

public record UserForLogin
{
    public string? Username { get; set; }
    
    public string? Password { get; set; }
};