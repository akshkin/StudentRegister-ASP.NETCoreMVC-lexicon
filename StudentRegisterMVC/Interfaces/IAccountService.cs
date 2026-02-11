using StudentRegisterMVC.DTOs;

namespace StudentRegisterMVC.Interfaces;

public interface IAccountService
{
    public Task<NewUserDto?> CreateIdentityUser(RegisterDto registerDto);
}
