using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegisterMVC.Models;

public class Teacher
{
    public int TeacherId { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

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

    //[Required]
    //[EmailAddress]
    //[DisplayName("Email Address")]
    //public string Email { get; set; }

    public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

}
