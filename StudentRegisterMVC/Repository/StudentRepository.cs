using Microsoft.EntityFrameworkCore;
using StudentRegisterMVC.Data;
using StudentRegisterMVC.Helpers;
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
    public async Task<IEnumerable<Student>> GetAllAsync(QueryOptions? queryOptions)
    {
        var students = _context.Students.AsQueryable();

        if (!string.IsNullOrEmpty(queryOptions.SearchQuery))
        {
            students = students.Where(s => s.LastName.StartsWith(queryOptions.SearchQuery));
        }
        if (queryOptions.SortBy != null)
        {
            students = queryOptions.SortBy switch
            {
                SortByOptions.FirstNameAsc => students.OrderBy(s => s.FirstName),
                SortByOptions.FirstNameDes => students.OrderByDescending(s => s.FirstName),
                SortByOptions.LastNameAsc => students.OrderBy(s => s.LastName),
                SortByOptions.LastNameDes => students.OrderByDescending(s => s.LastName),
                _ => students
            };
        }
    
        return students;
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
