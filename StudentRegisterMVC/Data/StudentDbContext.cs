using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Data;

public class StudentDbContext : IdentityDbContext<ApplicationUser>
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
    {
        
    }

    public DbSet<Student> Students { get; set;  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
