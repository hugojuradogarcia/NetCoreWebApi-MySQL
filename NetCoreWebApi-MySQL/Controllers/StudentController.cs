using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi_MySQL.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebApi_MySQL.Controllers
{
    [Route("/api/[controller]")]
    public class StudentController : InjectedController
    {
        public StudentController(StudentContext context) : base(context) { }

        // Get student with id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GeStudent(int id)
        {
            var student = await db.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // Add new student to db
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        { 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dept = await db.Departments.FindAsync(student.DepartmentID);
            if(dept == null)
            {
                ModelState.AddModelError("Department Id", $"Department {student.Department} does not exist");
                return BadRequest(ModelState);
            }

            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
            return Ok(new { StudentID = student.ID });
        }
    }
}
