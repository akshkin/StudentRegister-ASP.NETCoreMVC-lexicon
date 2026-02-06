using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentRegisterMVC.Helpers;
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
        public async Task<IActionResult> Index(QueryOptions queryOptions)
        {
            var students = await _studentRepository.GetAllAsync(queryOptions);

            var viewModel = new StudentIndexViewModel
            {
                Students = students,
                QueryOptions = queryOptions
            };
            return View(viewModel);
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

        public async Task<IActionResult> Edit(int? id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("FirstName, LastName, Email")] Student student)
        {
            if (!ModelState.IsValid) return View(student);

            var existingStudent = await _studentRepository.UpdateAsync(id, student);

            if (existingStudent == null) return NotFound();
          
            return RedirectToAction(nameof(Index));            
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _studentRepository.GetStudent(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await _studentRepository.DeleteAsync(id);

            if (student == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null) return NotFound();
            return View(student);
        }

        //public async Task<IActionResult> Search([Bind("SearchQuery")] QueryOptions queryOptions)
        //{
        //    var students = await _studentRepository.GetAllAsync(queryOptions);
        //}
    }
}
