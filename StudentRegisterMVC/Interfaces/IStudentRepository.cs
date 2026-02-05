using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Interfaces;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllAsync();

    public Task<Student> CreateAsync(Student student);
}
