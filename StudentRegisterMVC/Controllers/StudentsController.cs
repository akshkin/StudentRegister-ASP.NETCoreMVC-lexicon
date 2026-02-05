using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentRegisterMVC.Interfaces;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        // create a new student
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Email")] Student student)
        {
            var newStudent = await _studentRepository.CreateAsync(student);
            return RedirectToAction(nameof(Index));
        }
    }
}
