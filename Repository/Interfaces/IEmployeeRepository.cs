
using Models.Employees;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAll();
        public Task<Employee> GetById(int id);
        public Task Create(Employee employee);
        public Task Update(Employee employee);
        public Task DeleteById(int id);
    }
}
