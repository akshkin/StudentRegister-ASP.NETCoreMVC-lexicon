using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Interfaces;

public interface ITokenService
{
    public string CreateToken(ApplicationUser user);
}
