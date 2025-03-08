using Models.Departments;
using Models.Enums;

namespace Models.Employees;

public partial class Employee
{
    public int Id { get; set; }

    public string Dni { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public decimal Salary { get; set; } = 0;

    public int JobPositionId { get; set; }
    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
