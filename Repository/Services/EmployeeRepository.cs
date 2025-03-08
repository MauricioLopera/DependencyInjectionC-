
using Models.Dto;
using Models.Employees;
using Models.Enums;
using Repository.DataContext;
using Repository.Interfaces;

namespace Repository.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PeriferiaTestContext _dbContext;

        public EmployeeRepository(PeriferiaTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Employee employee)
        {
            _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChangesAsync();
        }

        public void Delete(Employee employee)
        {
            var reg = _dbContext.Employees.Where(w => w.Id == employee.Id).FirstOrDefault();
            _dbContext.Employees.Remove(reg);
            _dbContext.SaveChanges();
        }

        public List<EmployeeDto> GetAll()
        {
            List<EmployeeDto> employees = _dbContext.Employees
                                                    .Join(_dbContext.Departments, employee => employee.DepartmentId, department => department.Id, (employee, department) => new EmployeeDto
                                                    {
                                                        Id = employee.Id,
                                                        Dni = employee.Dni,
                                                        Name = employee.Name,
                                                        LastName = employee.LastName,
                                                        Email = employee.Email,
                                                        Salary = employee.Salary,
                                                        Department = department.Name,
                                                        JobPositionName = ((JobPosition)employee.JobPositionId).ToString()
                                                    })
                                                    .OrderBy(o => o.Name).ToList();

            return employees;
        }

        public EmployeeDto GetById(int id)
        {
            EmployeeDto employee = _dbContext.Employees
                                                    .Join(_dbContext.Departments, employee => employee.DepartmentId, department => department.Id, (employee, department) => new EmployeeDto
                                                    {
                                                        Id = employee.Id,
                                                        Dni = employee.Dni,
                                                        Name = employee.Name,
                                                        LastName = employee.LastName,
                                                        Email = employee.Email,
                                                        Salary = employee.Salary,
                                                        Department = department.Name,
                                                        JobPositionName = ((JobPosition)employee.JobPositionId).ToString()
                                                    })
                                                    .Where(w => Convert.ToInt32(w.Id) == id).FirstOrDefault();

            return employee;
        }

        public EmployeeDto GetByDni(string dni)
        {
            EmployeeDto employee = _dbContext.Employees
                                                    .Join(_dbContext.Departments, employee => employee.DepartmentId, department => department.Id, (employee, department) => new EmployeeDto
                                                    {
                                                        Id = employee.Id,
                                                        Dni = employee.Dni,
                                                        Name = employee.Name,
                                                        LastName = employee.LastName,
                                                        Email = employee.Email,
                                                        Salary = employee.Salary,
                                                        Department = department.Name,
                                                        JobPositionName = ((JobPosition)employee.JobPositionId).ToString()
                                                    })
                                                    .Where(w => w.Dni == dni).FirstOrDefault();

            return employee;
        }

        public List<EmployeeDto> GetByDepartment(int id)
        {
            List<EmployeeDto> employee = _dbContext.Employees
                                                    .Where(w => w.DepartmentId == id)
                                                    .Join(_dbContext.Departments, employee => employee.DepartmentId, department => department.Id, (employee, department) => new EmployeeDto
                                                    {
                                                        Id = employee.Id,
                                                        Dni = employee.Dni,
                                                        Name = employee.Name,
                                                        LastName = employee.LastName,
                                                        Email = employee.Email,
                                                        Salary = employee.Salary,
                                                        Department = department.Name,
                                                        JobPositionName = ((JobPosition)employee.JobPositionId).ToString()
                                                    })
                                                    .ToList();

            return employee;
        }

        public void Update(Employee employee)
        {
            var reg = _dbContext.Employees.Where(w => w.Id == employee.Id).FirstOrDefault();
            reg.Dni = employee.Dni;
            reg.Name = employee.Name;
            reg.LastName = employee.LastName;
            reg.Email = employee.Email;
            reg.Salary = employee.Salary;
            reg.DepartmentId = employee.DepartmentId;
            reg.JobPositionId = employee.JobPositionId;

            _dbContext.SaveChanges();
        }
    }
}
