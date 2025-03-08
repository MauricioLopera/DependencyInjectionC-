
using Models.Departments;

namespace Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Create(Department department);
        public void Update(Department department);
        public void Delete(Department department);
    }
}
