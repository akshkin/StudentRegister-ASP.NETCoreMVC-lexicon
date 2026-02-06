using Microsoft.EntityFrameworkCore;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
    {
        
    }

    public DbSet<Student> Students { get; set;  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                FirstName = "Harry",
                LastName = "Potter",
                Email = "harrypotter@gmail.com"
            },
             new Student
             {
                 StudentId = 2,
                 FirstName = "Ron",
                 LastName = "Weasley",
                 Email = "ronweasley@gmail.com"
             },
              new Student
              {
                  StudentId = 3,
                  FirstName = "Hermione",
                  LastName = "Granger",
                  Email = "hermionegranger1@gmail.com"
              }
            );
    }
}
