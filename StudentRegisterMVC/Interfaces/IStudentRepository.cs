using StudentRegisterMVC.Helpers;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Interfaces;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllAsync(QueryOptions? queryOptions);

    public Task<Student> CreateAsync(Student student);

    public Task<Student?> GetStudent(int? id);

    public Task<Student?> UpdateAsync(int? id, Student student);

    public Task<Student?> DeleteAsync(int? id);
}
