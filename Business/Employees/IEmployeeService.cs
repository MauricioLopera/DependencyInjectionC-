
using Models.Dto;
using Models.Employees;

namespace Business.Employees
{
    public interface IEmployeeService
    {
        public StandarResponseDto GetAll();
        public StandarResponseDto GetById(int id);
        public StandarResponseDto Create(EmployeeDto employee);
        public StandarResponseDto Update(EmployeeDto employee);
        public StandarResponseDto Delete(EmployeeDto employee);
    }
}
