
using Models.Departments;
using Models.Dto;

namespace Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<DepartmentDto> GetAll();
        public DepartmentDto GetById(int id);
        public Department GetIdByName(string name);
        public void Create(Department department);
        public void Update(Department department);
        public void Delete(Department department);
    }
}
