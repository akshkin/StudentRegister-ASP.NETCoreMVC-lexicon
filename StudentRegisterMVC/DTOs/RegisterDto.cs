using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegisterMVC.DTOs;

public class RegisterDto
{
    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [MaxLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [MaxLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [DisplayName("Email Address")]
    public string? EmailAddress { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Min length should be 8 characters")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string?  ConfirmPassword { get; set; }

    [Required]
    public string Role { get; set; } // Student or Teacher
}