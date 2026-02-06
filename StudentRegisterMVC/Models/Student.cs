using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegisterMVC.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [MaxLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [MaxLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [DisplayName("Email Address")]
    public string Email { get; set; }
}
