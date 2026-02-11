using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        
    }

    public DbSet<Student> Students { get; set;  }
    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Classroom> Classrooms { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Classroom>()
            .HasMany(cs => cs.Students)
            .WithMany(cs => cs.Classrooms)
            .UsingEntity(j => j.ToTable("ClassroomStudents"));

        modelBuilder.Entity<Classroom>()
            .HasMany(cs => cs.Teachers)
            .WithMany(s => s.Classrooms)
            .UsingEntity(j => j.ToTable("ClassroomTeachers"));

    }
}
