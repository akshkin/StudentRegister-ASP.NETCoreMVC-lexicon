using StudentRegisterMVC.Helpers;

namespace StudentRegisterMVC.Models;

public class StudentIndexViewModel
{
    public IEnumerable<Student> Students { get; set;  }

    public QueryOptions QueryOptions { get; set;  }

}
