namespace StudentRegisterMVC.Models;

public class Classroom
{
    public int ClassroomId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Student> Students { get; set; }

}