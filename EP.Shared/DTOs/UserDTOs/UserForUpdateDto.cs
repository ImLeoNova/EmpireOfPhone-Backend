using System.ComponentModel.DataAnnotations;

namespace EP.Shared.DTOs.UserDTOs;

public record UserForUpdateDto
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;
    
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;
    
    [Display(Name = "Address")]
    public string Address { get; set; } = string.Empty;
    
    [Display(Name = "City")]
    public string City { get; set; } = string.Empty;
    
    [Display(Name = "Country")]
    public string Country { get; set; } = string.Empty;
};