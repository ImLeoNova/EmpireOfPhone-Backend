namespace EP.Shared.DTOs.UserDTOs;

public record UserForRead
{
    public string Id { get; set; } = string.Empty;
    
    public string Username { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Role { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
        
    public string City { get; set; } = string.Empty;
    
    public string Country { get; set; } = string.Empty;
};