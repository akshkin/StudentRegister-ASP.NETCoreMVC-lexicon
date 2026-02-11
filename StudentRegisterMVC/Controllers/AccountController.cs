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
}
