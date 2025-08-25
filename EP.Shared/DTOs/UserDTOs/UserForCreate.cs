using System.ComponentModel.DataAnnotations;

namespace EP.Shared.DTOs.UserDTOs;

public record UserForCreate
{
    
    [Required]
    [MaxLength(50, ErrorMessage = "Username name cannot exceed 50 characters")]
    [MinLength(5, ErrorMessage = "Username should have at least 10 characters")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Username should contain only letters")]
    [Display(Name = "Username")]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
    [MinLength(6, ErrorMessage = "Password should have at least 6 characters")]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;
    
    [Compare("Password", ErrorMessage = "Password Do not Match")]
    public string PasswordConfirm { get; set; } = string.Empty;
    
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;
    
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Phone Number")] 
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Display(Name = "Address")]
    public string Address { get; set; } = string.Empty;
    
    [Display(Name = "City")]
    public string City { get; set; } = string.Empty;
    
    [Display(Name = "Country")]
    public string Country { get; set; } = string.Empty;
}