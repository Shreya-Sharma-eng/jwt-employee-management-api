using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}