using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddDepartment(CreateDepartmentDto dto)
        {
            var existingDepartment = _context.Departments
                .FirstOrDefault(x =>
                    x.DepartmentName == dto.DepartmentName);

            if (existingDepartment != null)
            {
                return BadRequest("Department already exists");
            }

            var department = new Department
            {
                DepartmentName = dto.DepartmentName
            };
            _context.Departments.Add(department);

            _context.SaveChanges();

            return Ok(department);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_context.Departments.ToList());
        }
    }
}