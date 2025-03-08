
using Models.Departments;
using Models.Dto;

namespace Business.Departments
{
    public interface IDepartmentService
    {
        public StandarResponseDto GetAll();
        public StandarResponseDto GetById(int id);
        public StandarResponseDto Create(Department department);
        public StandarResponseDto Update(Department department);
        public StandarResponseDto Delete(Department department);
    }
}
