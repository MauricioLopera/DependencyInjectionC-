
using Models.Employees;
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

        public async Task Create(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
