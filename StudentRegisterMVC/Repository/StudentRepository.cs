using Microsoft.EntityFrameworkCore;
using StudentRegisterMVC.Data;
using StudentRegisterMVC.Interfaces;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context)
    {
        _context = context;

    }

    // get all students
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> CreateAsync(Student student)
    {
        var newStudent = new Student();
        newStudent.FirstName = student.FirstName;
        newStudent.LastName = student.LastName;
        newStudent.Email = student.Email;

        await _context.Students.AddAsync(newStudent);
        await _context.SaveChangesAsync();
        return newStudent;
    }
}
