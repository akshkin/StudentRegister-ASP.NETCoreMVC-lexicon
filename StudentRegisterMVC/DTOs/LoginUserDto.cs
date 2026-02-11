using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegisterMVC.DTOs;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    [DisplayName("Email Address")]
    public string? EmailAddress { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Min length should be 8 characters")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
