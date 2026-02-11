using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudentRegisterMVC.Data;
using StudentRegisterMVC.DTOs;
using StudentRegisterMVC.Interfaces;
using StudentRegisterMVC.Models;
using StudentRegisterMVC.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRegisterMVC.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
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
           var newUser = await _accountService.CreateIdentityUser(registerDto);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        try
        {
            var existingUser = await _accountService.Login(loginUserDto);
            if (existingUser == null)
            {
                return BadRequest("Invalid password or email");
            }
            HttpContext.Session.SetString("jwt", existingUser.Token);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex) 
        {
            return BadRequest($"Failed to login {ex.Message}");
        }
    }

    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
