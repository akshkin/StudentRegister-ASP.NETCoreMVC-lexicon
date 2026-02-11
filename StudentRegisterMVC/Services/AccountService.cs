using Microsoft.AspNetCore.Identity;
using StudentRegisterMVC.DTOs;
using StudentRegisterMVC.Interfaces;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly ITeacherRepository _teacherRepo;
    private readonly IStudentRepository _studentRepository;

    public AccountService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService,
        ITeacherRepository teacherRepo,
        IStudentRepository studentRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _teacherRepo = teacherRepo;
        _studentRepository = studentRepository;
    }


    public async Task<NewUserDto?> CreateIdentityUser(RegisterDto registerDto)
    {
        try
        {
            var appUser = new ApplicationUser
            {
                UserName = registerDto.FirstName + registerDto.LastName,
                Email = registerDto.EmailAddress,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (createdUser.Succeeded)
            {
                // add to student or teacher table
                if (registerDto.Role == "Student")
                {
                    var newStudent = new Student
                    {
                        UserId = appUser.Id,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName
                    };
                    await _studentRepository.CreateAsync(newStudent);
                }
                else if (registerDto.Role == "Teacher")
                {
                    var newTeacher = new Teacher
                    {
                        UserId = appUser.Id,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName
                    };
                    var createdTeacher = await _teacherRepo.CreateTeacher(newTeacher);
                }

                var roleResolved = await _userManager.AddToRoleAsync(appUser, registerDto.Role);

                if (roleResolved.Succeeded)
                {
                    return new NewUserDto
                    {
                        UserName = appUser.UserName,
                        Email = appUser.Email,
                        Token = await _tokenService.CreateToken(appUser)
                    };
                }
                else
                {
                    throw new Exception(string.Join(",", roleResolved.Errors));
                }
            }
            else
            {
               throw new Exception(string.Join(",", createdUser.Errors));
            }
        }
        catch (Exception ex) 
        { 
            throw new Exception($"{ex.Message}", ex);
        }
    }

    public async Task<NewUserDto?> Login(LoginUserDto loginUserDto)
    {
        var existingUser = await _userManager.FindByEmailAsync(loginUserDto.EmailAddress);
        if (existingUser == null) return null;

        var isPasswordValid = await _signInManager.CheckPasswordSignInAsync(existingUser, loginUserDto.Password, false);
        if (!isPasswordValid.Succeeded)  return null;

        return new NewUserDto
        {
            UserName = existingUser.UserName,
            Email = loginUserDto.EmailAddress,
            Token = await _tokenService.CreateToken(existingUser)
        };
    }

}
