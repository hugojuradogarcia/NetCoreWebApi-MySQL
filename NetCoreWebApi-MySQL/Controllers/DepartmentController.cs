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
    public class DepartmentController : InjectedController
    {
       public DepartmentController(StudentContext context) : base(context) { }

        // Get department with given id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await db.Departments.FindAsync(id);
            if (department == default(Department)) 
            {
                return NotFound();
            }

            return Ok(department);
        }

        // Add a department to db
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await db.AddAsync(department);
            await db.SaveChangesAsync();
            return Ok(department.ID);
        }
    }

    public class InjectedController: ControllerBase
    {
        protected readonly StudentContext db;

        public InjectedController(StudentContext context)
        {
            db = context;
        }
    }
}
