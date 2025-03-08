﻿using Models.Employees;

namespace Models.Departments;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
