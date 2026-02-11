using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(ApplicationUser user);
}
