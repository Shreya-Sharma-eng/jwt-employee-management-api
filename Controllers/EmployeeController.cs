using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE EMPLOYEE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddEmployee(CreateEmployeeDto dto)
        {
            var department = _context.Departments
                .FirstOrDefault(x => x.Id == dto.DepartmentId);

            if (department == null)
            {
                return BadRequest("Invalid Department");
            }
            
            var existingEmployee = _context.Employees
                .FirstOrDefault(x => x.Email == dto.Email);

            if (existingEmployee != null)
            {
                return BadRequest("Employee already exists");
            }

            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId
            };

            _context.Employees.Add(employee);

            _context.SaveChanges();

            return Ok(employee);
        }

        // GET ALL EMPLOYEES
        [Authorize]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees
                .Include(x => x.Department)
                .Select(x => new EmployeeResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = x.Salary,
                    DepartmentName = x.Department.DepartmentName
                })
                .ToList();

            return Ok(employees);
        }

        // GET EMPLOYEE BY ID
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.Employees
                .Include(x => x.Department)
                .Where(x => x.Id == id)
                .Select(x => new EmployeeResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = x.Salary,
                    DepartmentName = x.Department.DepartmentName
                })
                .FirstOrDefault();

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        // UPDATE EMPLOYEE
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(
            int id,
            UpdateEmployeeDto dto)
        {
            var employee = _context.Employees
                .FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.Salary = dto.Salary;
            employee.DepartmentId = dto.DepartmentId;

            _context.SaveChanges();

            return Ok(employee);
        }

        // DELETE EMPLOYEE
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees
                .FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _context.Employees.Remove(employee);

            _context.SaveChanges();

            return Ok("Employee deleted successfully");
        }
    }
}