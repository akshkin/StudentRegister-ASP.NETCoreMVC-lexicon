using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Interfaces;

public interface ITeacherRepository
{
    public Task<Teacher> CreateTeacher(Teacher teacher);
}
