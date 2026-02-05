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

    public async Task<Student?> GetStudent(int? id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

        if (student == null) return null;

        return student;
    }

    public async Task<Student> UpdateAsync(int? id, Student student)
    {
        var existingStudent = await GetStudent(id);

        if (student == null) return null;

        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.Email = student.Email;

        await _context.SaveChangesAsync();
        return existingStudent;
    }

    public async Task<Student?> DeleteAsync(int? id)
    {
        var existingStudent = await GetStudent(id);

        if (existingStudent == null) return null;

        _context.Students.Remove(existingStudent);
        await _context.SaveChangesAsync();

        return existingStudent;
    }
}
