using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRegisterMVC.DTOs;
using StudentRegisterMVC.Interfaces;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, ITokenService tokenService, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appUser = new ApplicationUser
            {
                UserName = registerDto.FirstName + registerDto.LastName,
                Email = registerDto.EmailAddress,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
             
            if (createdUser.Succeeded)
            {
                //if (registerDto.Role == "Student") await 
                // add to student or teacher table

                var roleResolved = await _userManager.AddToRoleAsync(appUser, registerDto.Role);
                
                if (roleResolved.Succeeded)
                {
                    return Ok(new NewUserDto 
                    { 
                        UserName = appUser.UserName, 
                        Email = appUser.Email, 
                        Token = _tokenService.CreateToken(appUser) 
                    });
                }
                else
                {
                    return StatusCode(500, roleResolved.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
