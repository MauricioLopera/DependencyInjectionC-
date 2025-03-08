
using Models.Dto;
using Models.Employees;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<EmployeeDto> GetAll();
        public EmployeeDto GetById(int id);
        public EmployeeDto GetByDni(string dni);
        public List<EmployeeDto> GetByDepartment(int id);
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Delete(Employee employee);
    }
}
